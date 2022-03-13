using System.Collections;
using System.Collections.Generic;
using Config;
using GUI;
using Main;
using Player;
using SampleGameObject;
using UnityEngine;
using Zenject;
using static SampleGameObject.SampleGameObjectView;

public class SimpleInstaller : MonoInstaller
{
    private GameObject _samplePrefab;
    
    public override void InstallBindings()
    {
        SetPrefabs();
        SetBindings();
        SetSignals();
        SetFactories();
    }

    private void SetFactories()
    {
        Container.BindFactory<
                SampleGameObjectView.InitArgs, 
                SampleGameObjectView, 
                SampleGameObjectView.Factory>()
            .FromComponentInNewPrefab(_samplePrefab);
        
    }

    private void SetPrefabs()
    {
        _samplePrefab = Resources.Load<GameObject>("Prefabs/SergeCraft/Sample");
    }

    private void SetSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<SampleObjectChangedSignal>();
    }

    private void SetBindings()
    {
        Container.BindInterfacesTo<HardcodeConfigManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<SimpleGameController>().AsSingle();
        Container.BindInterfacesAndSelfTo<SimplePlayerController>().AsSingle();
        Container.BindInstance(new PlayerInputActions()).AsSingle();
        Container.Bind<IGameObjectController>().To<SampleGameObjectController>().AsTransient();
    }
}
