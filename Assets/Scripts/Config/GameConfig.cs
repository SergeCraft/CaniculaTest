using System.Collections.Generic;
using Placeables;
using UnityEngine;

namespace Config
{
    public class GameConfig
    {
        public Dictionary<PlaceableTypes, PlaceableConfig> PlaceableConfigs { get; set; }
        public Dictionary<PlaceableRegions, List<PlaceableTypes>> PlaceableRegionBindings { get; set; }
        

        public GameConfig()
        {
            
        }

        public struct PlaceableConfig
        {
            public float MovespeedMin { get; }
            public float MovespeedMax { get; }
            public int CountMax { get; }
            public int PosZ { get; }
            
            public Vector2 Pivot { get; }
            
            public Vector2 Scale { get; }

            public PlaceableConfig(
                float movespeedMin, 
                float movespeedMax, 
                int countMax, 
                int posZ,
                Vector2 pivot,
                Vector2 scale)
            {
                MovespeedMin = movespeedMin;
                MovespeedMax = movespeedMax;
                CountMax = countMax;
                PosZ = posZ;
                Pivot = pivot;
                Scale = scale;
            }
        }
    }
}