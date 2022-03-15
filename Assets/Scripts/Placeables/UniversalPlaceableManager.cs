using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Main;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Placeables
{
    public class UniversalPlaceableManager : IPlaceableManager, IDisposable
    {
        private SignalBus _signalBus;
        private DiContainer _container;
        
        
        public List<IPlaceableController> PlacedObjects { get; }
        public GameConfig Config { get; private set; }
        
        
        public UniversalPlaceableManager(
            SignalBus signalBus,
            DiContainer container, 
            IGameConfigManager configMgr)
        {
            _signalBus = signalBus;
            _container = container;

            Config = configMgr.Config;
            PlacedObjects = new List<IPlaceableController>();

            SubscribeToSignals();
        }


        private void CreateRandomPlaceableAtRegion(
            Vector2 initialPosition, 
            GameObject parentRegion)
        {
            var regionType = Helper.ConvertTagToType(parentRegion.tag);
            
            var availableTypes = 
                Config.PlaceableRegionBindings[regionType];
            if (availableTypes.Count > 0)
            {
                PlaceableTypes type = availableTypes[Random.Range(0, availableTypes.Count)];
            
                List<IPlaceableController> samePlaceables = 
                    PlacedObjects.Where(x => x.Type == type).ToList();

                GameConfig.PlaceableConfig config = Config.PlaceableConfigs[type];
            
                if (samePlaceables.Count == config.CountMax)
                    RemovePlaceable(samePlaceables.First());

                Vector3[] dirs = {Vector3.left, Vector3.right};
                Vector3 dir = dirs[Random.Range(0, 2)];
            
                float movespeed = Random.Range(config.MovespeedMin, config.MovespeedMax);
            
                IPlaceableController obj = _container.Resolve<IPlaceableController>();
                obj.Construct(
                    initialPosition, 
                    dir, 
                    movespeed, 
                    regionType, 
                    type,
                    config);
            

                PlacedObjects.Add(obj);
            }
        }


        public void Dispose()
        {
            UnsubscribeFromSignals();
        }
        

        private void RemovePlaceable(IPlaceableController placeable)
        {
            PlacedObjects.Remove(placeable);
            placeable.Dispose();
        }
        
        private void SubscribeToSignals()
        {
            _signalBus.Subscribe<CreatePlaceableRequestSignal>(OnCreateplaceableRequested);
        }
        
        private void UnsubscribeFromSignals()
        {
            _signalBus.Unsubscribe<CreatePlaceableRequestSignal>(OnCreateplaceableRequested);
        }
        
        
        public void OnCreateplaceableRequested(CreatePlaceableRequestSignal signal)
        {
            CreateRandomPlaceableAtRegion(signal.InitialPosition, signal.ParentRegion);
        }

    }
}