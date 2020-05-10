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
        public Vector3 _spawnPosition;
        
        [SerializeField] [Range(1, 100)] private int numberOfPlatforms;
        [SerializeField] private bool generateNewSegmentOnLastPlatform;
        [SerializeField] private PlatformType[] platformsType;

        private PlatformFactory _platformFactory;
        private Transform _procGenRoot;
        private void OnEnable()
        {
            _platformFactory = new PlatformFactory();
            _spawnPosition = Vector3.zero;
        }


        public void Generate()
        {
            //_spawnPosition = Vector3.zero;
            _procGenRoot = new GameObject("ProcGen Root").transform;
            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                var platfomType = platformsType[Random.Range(0, platformsType.Length)];
                GeneratePlatform(platfomType);
            }

            if (generateNewSegmentOnLastPlatform)
            {
                var child = _procGenRoot.GetChild(_procGenRoot.childCount - 1).GetComponent<PlatformBehaviour>();
                child.GenerateNewSegment();
            }
        }

        private void GeneratePlatform(PlatformType platformType)
        {
            var platform = _platformFactory.GetPlatform(platformType);
            platform.transform.position = _spawnPosition;
            _spawnPosition = new Vector3(_spawnPosition.x + platform.GetBorder(), 0.0f);
            platform.transform.parent = _procGenRoot;
        }
    }
}