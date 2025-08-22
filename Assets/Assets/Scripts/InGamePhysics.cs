using Bran;
using UnityEngine;

public class InGamePhysics : MonoBehaviour
{
    PlayerMovement playerMovement;
    private InputReader input;

    private bool canPressButton;

    internal float gravity = 9.81f;

    void Start()
    { 
        input = InputReader.Instance;
        canPressButton = true;
    }

    void AdjustPlayerGravity(float gravityValue)
    {
        if (input.InteractTrigger && canPressButton)
        {
            gravity = gravityValue * gravity;
            canPressButton = true;
        }
    }

}
