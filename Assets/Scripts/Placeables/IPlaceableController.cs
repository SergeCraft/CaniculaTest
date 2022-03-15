using System;
using Config;
using Main;
using UnityEngine;

namespace Placeables
{
    public interface IPlaceableController: IDisposable
    {
        MonoBehaviour View { get; }
        PlaceableRegions Region { get; }
        PlaceableTypes Type { get;  }
        Vector3 Position { get; }

        void Construct(
            Vector3 initPos,
            Vector3 direction,
            float movespeed,
            PlaceableRegions region,
            PlaceableTypes type,
            GameConfig.PlaceableConfig config);

    }
}