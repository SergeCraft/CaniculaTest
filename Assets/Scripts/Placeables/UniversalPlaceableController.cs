using System;
using Config;
using Main;
using UnityEngine;
using Zenject;

namespace Placeables
{
    public class UniversalPlaceableController : IPlaceableController
    {
        private UniversalPlaceableView.Factory _factory;
        private float _movespeed;
        private Vector3 _direction;
        private Vector3 _position;
        private GameConfig.PlaceableConfig _config;
        
        
        public MonoBehaviour View { get; private set; }
        public PlaceableRegions Region { get; private set; }
        public PlaceableTypes Type { get; private set; }

        public Vector3 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                if (View) View.transform.position = _position;
            }
        }



        public UniversalPlaceableController(UniversalPlaceableView.Factory factory)
        {
            _factory = factory;
        }


        public void Construct(
            Vector3 initPos, 
            Vector3 direction, 
            float movespeed, 
            PlaceableRegions region, 
            PlaceableTypes type,
            GameConfig.PlaceableConfig config)
        {
            _config = config;
            _direction = direction;
            _movespeed = movespeed;

            Position = initPos;
            Region = region;
            Type = type;
            
            GenerateView();
        }

        public void Dispose()
        {
            if (View) GameObject.Destroy(View.transform.gameObject);
        }

        private void GenerateView()
        {
            View = _factory.Create(new UniversalPlaceableView.InitArgs(
                Type,
                Position,
                _direction,
                _movespeed,
                _config));
        }
    }
}