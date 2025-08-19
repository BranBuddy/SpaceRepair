using UnityEngine;

public class InGamePhysics : MonoBehaviour
{
    internal float gravity = 9.81f;
    PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustPlayerGravity();  
    }

    void AdjustPlayerGravity()
    {
        if (playerMovement.GroundCheck())
        {
            Debug.Log("Yes");
        }
        else
        {
            playerMovement.currentMovement.y -= gravity * Time.deltaTime;
            Debug.Log("nO");
        }
    }
    
}
