using Behaviours;
using Enums;
using Factories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProcGen
{
    [CreateAssetMenu(fileName = "LevelSegmentSettingsData", menuName = "Data/LevelSettings/LevelSegmentSettingsData")]
    public sealed class LevelSegmentSettingsData : ScriptableObject
    {
        public Vector3 spawnPosition;
        
        [SerializeField] [Range(1, 100)] private int numberOfPlatforms;
        [SerializeField] private bool generateNewSegmentOnLastPlatform;
        [SerializeField] private PlatformType[] platformsType;

        private PlatformFactory _platformFactory;
        private Transform _segmentRoot;
        private void OnEnable()
        {
            _platformFactory = new PlatformFactory();
            spawnPosition = Vector3.zero;
        }


        public void Generate()
        {
            _segmentRoot = new GameObject("Segment Root").transform;
            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                var platfomType = platformsType[Random.Range(0, platformsType.Length)];
                GeneratePlatform(platfomType);
            }

            if (generateNewSegmentOnLastPlatform)
            {
                var child = _segmentRoot.GetChild(_segmentRoot.childCount - 1).GetComponent<PlatformBehaviour>();
                child.GenerateNewSegment();
            }
        }

        private void GeneratePlatform(PlatformType platformType)
        {
            var platform = _platformFactory.GetPlatform(platformType);
            platform.transform.position = spawnPosition;
            spawnPosition = new Vector3(spawnPosition.x + platform.GetBorder(), 0.0f);
            platform.transform.parent = _segmentRoot;
        }
    }
}