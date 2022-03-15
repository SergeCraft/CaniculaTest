using Placeables;
using UnityEngine;

namespace Main
{
    public static class Helper
    {
        public static PlaceableRegions ConvertTagToType(string tag)
        {
            switch (tag)
            {
                case "Beach": return PlaceableRegions.Beach;
                case "Sea": return PlaceableRegions.Sea;
                case "Sky": return PlaceableRegions.Sky;
                default: return PlaceableRegions.Sea;
            }
        }
    }
}