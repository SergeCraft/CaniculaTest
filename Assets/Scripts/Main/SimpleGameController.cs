using System;
using GUI;
using SampleGameObject;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Main
{
    public class SimpleGameController: IDisposable
    {
        private SignalBus _signalBus;
        private DiContainer _container;
        private SampleGameObjectView.Factory _sgoFactory;


        public SimpleGameController(
            SignalBus signalBus,
            SampleGameObjectView.Factory sgoFactory)
        {
            _sgoFactory = sgoFactory;
            _signalBus = signalBus;
            


            SubscribeToSignals();
            Restart();
        }
        
        
        public void Dispose()
        {
            UnsubscribeFromSignals();
        }

        
        private void SubscribeToSignals()
        {
        }


        private void UnsubscribeFromSignals()
        {
        } 

        private void Restart()
        {
            Debug.Log("Simple game controller restart");
            _sgoFactory.Create(new GameObjectViewBase.InitArgs(1));
        }
        
        

    }
}