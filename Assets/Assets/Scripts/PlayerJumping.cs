using Bran;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumping : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private InGamePhysics inGamePhysics;
    private PlayerInput playerControls;

    private InputReader input;

    private bool isJumping;

    internal Vector3 playerVelocity;

    private float jumpHeight; 

    private CharacterController characterController;
    void Start()
    {
        playerMovement = this.transform.GetComponent<PlayerMovement>();
        inGamePhysics = GetComponent<InGamePhysics>();
        characterController = GetComponent<CharacterController>();
        input = InputReader.Instance;
    }

    // Update is called once per frame
    public void Update()
    {
        Jumping();
    }
   
    private void Jumping()
    {


        if (playerMovement.GroundCheck())
        {

            jumpHeight = 5;

            playerMovement.currentMovement.y = 0;

            if (input.JumpTrigger)
            {
                playerMovement.currentMovement.y += Mathf.Sqrt(jumpHeight * inGamePhysics.gravity);
                Debug.Log("Hi");

                characterController.Move(playerMovement.currentMovement * Time.deltaTime);
            }

        } 
        else
        {
            playerMovement.currentMovement.y -= inGamePhysics.gravity * Time.deltaTime;
        }


    }


}
