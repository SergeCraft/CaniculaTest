using System;
using Main;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GUI
{
    public class GUIView : MonoBehaviour, IGUIView, IDisposable
    {
        private SignalBus _signalBus;


        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
            
            SubscribeToSignals();
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
    }
}