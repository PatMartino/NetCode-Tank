using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    [CreateAssetMenu(fileName = "New Input Reader", menuName = "Input/Input Reader")]
    public class InputReader : ScriptableObject, Controls.IPlayerActions
    {
        public event Action<Vector2> MoveEvent;
        public event Action<bool> PrimaryFireEvent;
        public Vector2 AimPosition { get; private set; }
        private Controls _controls;
        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPrimaryFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                PrimaryFireEvent?.Invoke(true);
            }
            else if (context.canceled)
            {
                PrimaryFireEvent?.Invoke(false); 
            }
            
        }

        public void OnAim(InputAction.CallbackContext context)
        {
            AimPosition = context.ReadValue<Vector2>();
        }
    }
}
