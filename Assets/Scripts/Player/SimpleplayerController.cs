using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class SimplePlayerController : IPlayerController, IDisposable
    {
        private PlayerInputActions _actions;
        private Camera _cam;
        

        public SimplePlayerController(PlayerInputActions actions)
        {
            _actions = actions;
            _actions.Player.Enable();
            _cam = GameObject.Find("Main Camera").GetComponent<Camera>();

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
            Vector3 negativeMousePosition = new Vector3(
                mousePosition.x,
                mousePosition.y,
                Mathf.Infinity);
            
            Debug.Log($"Click on {mousePosition}");

            RaycastHit2D hit = Physics2D.Raycast(
                mousePosition, Vector3.forward);
            Debug.DrawRay(mousePosition, Vector3.forward, Color.green, 10000);

            if (hit)
            {
                Debug.Log($"Hit on {hit.collider.gameObject.name}");
            }
        }
    }
}