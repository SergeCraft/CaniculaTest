using UnityEngine.InputSystem;

namespace Player
{
    public interface IPlayerController
    {
        void OnClick(InputAction.CallbackContext callback);
    }
}