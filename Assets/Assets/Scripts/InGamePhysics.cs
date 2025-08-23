using Bran;
using UnityEngine;

public class InGamePhysics : MonoBehaviour
{
    PlayerMovement playerMovement;
    private InputReader input;

    private bool canPressButton;

    internal float gravity = 9.81f;

    [SerializeField] private bool zeroGravity;

    void Start()
    { 
        input = InputReader.Instance;
        canPressButton = true;
    }

    internal void AdjustPlayerGravity(float gravityValue)
    {
        if (input.InteractTrigger)
        {
            Debug.Log("Yo");
            gravity = gravityValue * gravity;
        }
    }
    
}
