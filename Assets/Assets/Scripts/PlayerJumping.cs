using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private InGamePhysics inGamePhysics;
    void Start()
    {
        playerMovement = this.transform.GetComponent<PlayerMovement>();
        inGamePhysics = GetComponent<InGamePhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();
    }
    public void Jumping()
    {
        if (Input.GetButtonDown("Jump") && playerMovement.GroundCheck())
        {
            playerMovement.currentMovement.y += 5 * inGamePhysics.gravity * Time.deltaTime;
            playerMovement.currentMovement.y = 5;
        }
    }
}
