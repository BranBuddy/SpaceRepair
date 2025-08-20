using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bran
{

    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject, PlayerControls.IGameplayActions, PlayerControls.IUIActions
    {
        private PlayerControls playerControls;

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.Gameplay.SetCallbacks(this);
                playerControls.UI.SetCallbacks(this);
            }

            SetGameplay();
        }

        private void SetGameplay()
        {
            playerControls.Gameplay.Enable();
            playerControls.UI.Disable();
        }

        private void SetUI()
        {
            playerControls.UI.Enable();
            playerControls.Gameplay.Disable();
        }

        public event Action<Vector2> MoveEvent;

        public event Action JumpEvent;
        public event Action JumpCanceledEvent;

        public event Action InteractEvent;

        public event Action PauseEvent;
        public event Action ResumeEvent;


        public void OnInteract(InputAction.CallbackContext context)
        {

        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                JumpEvent?.Invoke();
            }

            if(context.phase == InputActionPhase.Canceled)
            {
                JumpCanceledEvent?.Invoke();
            }
        }

        public void OnLook(InputAction.CallbackContext context)
        {

        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnPause(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PauseEvent?.Invoke();
                SetUI();
            }
        }

        public void OnResume(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ResumeEvent?.Invoke();
                SetGameplay();
            }
        }
    }

}