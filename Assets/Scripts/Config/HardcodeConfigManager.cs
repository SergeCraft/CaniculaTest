using System.Collections.Generic;
using Placeables;
using UnityEngine;

namespace Config
{
    public class HardcodeConfigManager : IGameConfigManager
    {
        private GameConfig _config;

        public GameConfig Config
        {
            get
            {
                return _config;
            }
        }

        public HardcodeConfigManager()
        {
            SetupDefaultConfig();
        }

        
        public GameConfig GetConfig()
        {
            return _config;
        }
        
        
        private void SetupDefaultConfig()
        {
            _config = new GameConfig();
            _config.PlaceableConfigs = new Dictionary<PlaceableTypes, GameConfig.PlaceableConfig>()
            {
                {PlaceableTypes.Ball, new GameConfig.PlaceableConfig(
                    0.0f, 0.0f, 2, 2, Vector2.zero, Vector2.one * 100)},
                {PlaceableTypes.Cloud, new GameConfig.PlaceableConfig(
                    0.0f, 100.0f, 2, 13, Vector2.zero, Vector2.one * 100)},
                {PlaceableTypes.Palm, new GameConfig.PlaceableConfig(
                    0.0f, 0.0f, 2, 1, new Vector2(0.0f, -300.0f), Vector2.one * 100)},
                {PlaceableTypes.Sun, new GameConfig.PlaceableConfig(
                    0.0f, 1.0f, 1, 14, Vector2.zero, new Vector2(0.6f, 0.6f) * 100)},
                {PlaceableTypes.SeaStar, new GameConfig.PlaceableConfig(
                    3.0f, 7.0f, 2, 3, Vector2.zero, Vector2.one * 100)}
            };
            
            _config.PlaceableRegionBindings = new Dictionary<PlaceableRegions, List<PlaceableTypes>>()
            {
                {PlaceableRegions.Beach, new List<PlaceableTypes>()
                {
                    PlaceableTypes.Ball,
                    PlaceableTypes.Palm,
                    PlaceableTypes.SeaStar
                }},
                {PlaceableRegions.Sea, new List<PlaceableTypes>()},
                {PlaceableRegions.Sky, new List<PlaceableTypes>()
                {
                    PlaceableTypes.Cloud,
                    PlaceableTypes.Sun
                }}
            };
        }

        public void UpdateConfig(GameConfig config)
        {
            Debug.Log("Config unupdateable with hardcode config manager");
        }

        public void SaveConfig()
        {
            Debug.Log("Config unsaveable with hardcode config manager");
        }
    }
}