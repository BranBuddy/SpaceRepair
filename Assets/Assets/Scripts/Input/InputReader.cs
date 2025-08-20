using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Bran
{
    public class InputReader : MonoBehaviour
    {
        [SerializeField] private InputActionAsset playerControls;

        [SerializeField] private string actionMapName = "Gameplay";

        [SerializeField] private string move = "Move";
        [SerializeField] private string jump = "Jump";
        [SerializeField] private string look = "Look";

        private InputAction moveAction;
        private InputAction jumpAction;
        private InputAction lookAction;

        public Vector2 MoveInput { get; private set; }
        public Vector2 LookInput { get; private set; }
        public bool JumpTrigger { get; private set; }

        public static InputReader Instance { get; private set; }

        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
            jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
            lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);

            RegisterInputAction();
        }

        void RegisterInputAction()
        {
            moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
            moveAction.canceled += context => MoveInput = context.ReadValue<Vector2>();

            lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
            lookAction.canceled += context => LookInput = context.ReadValue<Vector2>();

            jumpAction.performed += context => JumpTrigger = true;
            jumpAction.canceled += context => JumpTrigger = false;
        }

        private void OnEnable()
        {
            moveAction.Enable();
            jumpAction.Enable();
            lookAction.Enable();
        }

    }
}