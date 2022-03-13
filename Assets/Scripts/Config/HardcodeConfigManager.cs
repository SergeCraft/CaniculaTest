using System.Collections.Generic;
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