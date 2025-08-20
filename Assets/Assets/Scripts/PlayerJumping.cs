using Bran;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private InGamePhysics inGamePhysics;

    [SerializeField] private InputReader input;

    [SerializeField] private float jumpSpeed;

    private bool isJumping;
    void Start()
    {
        playerMovement = this.transform.GetComponent<PlayerMovement>();
        inGamePhysics = GetComponent<InGamePhysics>();

        input.JumpEvent += HandleJump;
        input.JumpCanceledEvent += HandleJumpCanceled;
    }

    // Update is called once per frame
    public void Update()
    {
        Jumping();
    }
   
    private void Jumping()
    {
        if (isJumping)
        {
            Debug.Log("Works");
            transform.position += new Vector3(0, 3, 0) * (jumpSpeed * Time.deltaTime);
        }
    }

    private void HandleJump()
    {
        isJumping = true;
    }

    private void HandleJumpCanceled()
    {
        isJumping = false;
    }

}
