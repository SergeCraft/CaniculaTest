using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class SimplePlayerController : IPlayerController, IDisposable
    {
        private PlayerInputActions _actions;
        

        public SimplePlayerController(PlayerInputActions actions)
        {
            _actions = actions;
            _actions.Player.Enable();

            SubscribeToSignals();
        }
        
        public void Dispose()
        {
            UnsubscribeFromSignals();
        }

        
        private void SubscribeToSignals()
        {
            _actions.Player.PlaceSomething.performed += OnClick;
        }


        private void UnsubscribeFromSignals()
        {
            _actions.Player.PlaceSomething.performed -= OnClick;
        }
        
        
        public void OnClick(InputAction.CallbackContext callback)
        {
            Debug.Log($"Click on {Mouse.current.position.ReadValue()}");
        }
    }
}