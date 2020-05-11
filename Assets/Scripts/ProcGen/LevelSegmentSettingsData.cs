using Behaviours;
using Enums;
using Factories;
using Structs;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;

namespace ProcGen
{
    [CreateAssetMenu(fileName = "LevelSegmentSettingsData", menuName = "Data/LevelSettings/LevelSegmentSettingsData")]
    public sealed class LevelSegmentSettingsData : ScriptableObject
    {
        public Vector3 spawnPosition;

        [SerializeField] [Range(1, 100)] private int numberOfPlatforms;
        [SerializeField] private bool generateNewSegmentOnLastPlatform;
        [SerializeField] private PlatformData[] platformsType;

        private PlatformFactory _platformFactory;
        private TrapFactory _trapFactory;
        private Transform _segmentRoot;

        private void OnEnable()
        {
            _platformFactory = new PlatformFactory();
            _trapFactory = new TrapFactory();
            spawnPosition = Vector3.zero;
        }


        public void Generate()
        {
            _segmentRoot = new GameObject("Segment Root").transform;
            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                var platform = platformsType[Random.Range(0, platformsType.Length)];
                GeneratePlatform(platform);
            }

            if (generateNewSegmentOnLastPlatform)
            {
                var child = _segmentRoot.GetChild(_segmentRoot.childCount - 1).GetComponent<PlatformBehaviour>();
                child.GenerateNewSegment();
            }
        }

        private void GeneratePlatform(PlatformData platformData)
        {
            var platform = _platformFactory.GetPlatform(platformData.type);
            platform.transform.position = spawnPosition;
            spawnPosition =
                new Vector3(
                    spawnPosition.x + platform.GetBorder() +
                    Random.Range(platformData.randomMargin.x, platformData.randomMargin.y),
                    Random.Range(platformData.randomHeight.x, platformData.randomHeight.y));
            platform.transform.parent = _segmentRoot;

            if (platformData.trapData.creationChance > Random.Range(0,100))
            {
                var trap = _trapFactory.GetTrap(platformData.trapData.type);
                trap.transform.parent = platform.transform;
                trap.transform.localPosition = platform.GetPointSpawnTrap();
            }
        }
    }
}