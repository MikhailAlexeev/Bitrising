using Enums;
using Factories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProcGen
{
    [CreateAssetMenu(fileName = "LevelSegmentSettingsData", menuName = "Data/LevelSettings/LevelSegmentSettingsData")]
    public sealed class LevelSegmentSettingsData : ScriptableObject
    {
        [SerializeField] [Range(1, 100)] private int numberOfPlatforms;
        [SerializeField] private PlatformType[] platformsType;

        private PlatformFactory _platformFactory;
        private Vector3 _spawnPosition;
        private void OnEnable()
        {
            _platformFactory = new PlatformFactory();
            _spawnPosition = Vector3.zero;
        }


        public void Generate()
        {
            _spawnPosition = Vector3.zero;
            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                var platfomType = platformsType[Random.Range(0, platformsType.Length)];
                GeneratePlatform(platfomType);
            }
        }

        private void GeneratePlatform(PlatformType platformType)
        {
            var platform = _platformFactory.GetPlatform(platformType);
            platform.transform.position = _spawnPosition;
            _spawnPosition = new Vector3(_spawnPosition.x + platform.GetBorder(), 0.0f);
        }
    }
}