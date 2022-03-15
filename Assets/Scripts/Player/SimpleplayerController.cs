using System;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class SimplePlayerController : IPlayerController, IDisposable
    {
        private PlayerInputActions _actions;
        private Camera _cam;
        private SignalBus _signalBus;

        public SimplePlayerController(PlayerInputActions actions, SignalBus signalBus)
        {
            _actions = actions;
            _actions.Player.Enable();
            _cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            _signalBus = signalBus;

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
            Vector3 mousePosition = _cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = -10;

            Debug.Log($"Click on {mousePosition}");

            RaycastHit2D hit = Physics2D.Raycast(
                mousePosition, Vector3.forward);

            if (hit)
            {
                Debug.Log($"Hit on {hit.collider.gameObject.name}");
                _signalBus.Fire(new CreatePlaceableRequestSignal(
                    mousePosition,
                    hit.collider.gameObject));
            }
        }
    }
}