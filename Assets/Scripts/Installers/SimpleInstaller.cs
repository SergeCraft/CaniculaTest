using System.Collections;
using System.Collections.Generic;
using Config;
using Main;
using Placeables;
using Player;
using UnityEngine;
using Zenject;

public class SimpleInstaller : MonoInstaller
{
    private GameObject _placeablePrefab;
    
    public override void InstallBindings()
    {
        SetPrefabs();
        SetBindings();
        SetSignals();
        SetFactories();
    }

    private void SetFactories()
    {
        Container.BindFactory<UniversalPlaceableView.InitArgs, UniversalPlaceableView, UniversalPlaceableView.Factory>()
            .FromComponentInNewPrefab(_placeablePrefab);
        
    }

    private void SetPrefabs()
    {
        _placeablePrefab = Resources.Load<GameObject>("Prefabs/SergeCraft/Placeable");
    }

    private void SetSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<CreatePlaceableRequestSignal>();
    }

    private void SetBindings()
    {
        Container.BindInterfacesTo<HardcodeConfigManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<UniversalPlaceableManager>().AsSingle();
        Container.BindInstance(new PlayerInputActions()).AsSingle();
        Container.BindInterfacesAndSelfTo<SimplePlayerController>().AsSingle();
        Container.BindInterfacesTo<UniversalPlaceableController>().AsTransient();
    }
}
