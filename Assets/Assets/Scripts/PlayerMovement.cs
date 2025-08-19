
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private InGamePhysics inGamePhysics;

    //Input Variables
    private float verticalInput;    
    private float horizontalInput;
    public Vector3 currentMovement = Vector3.zero;

    //Player Attributes
    internal float speed = 2f;

    //GroundCheck Variables
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    void Start()
    {
        inGamePhysics = GetComponent<InGamePhysics>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public void Update()
    {
        Movement();
    }

    public void Movement()
    {
     
        Vector3 horizontalMovement = new Vector3(horizontalInput, 0, verticalInput);

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        

        currentMovement.x = horizontalMovement.x * speed;
        currentMovement.z = horizontalMovement.z * speed;
  
        characterController.Move(currentMovement * Time.deltaTime * speed);  

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance, boxSize);
    }

    public bool GroundCheck()
    {
        if(Physics.BoxCast(transform.position,boxSize, -transform.up,transform.rotation,maxDistance, layerMask))
        {
            

            return true;
        }
        else
        {
            

            return false;
        }
    }
    public void Jumping()
    {
        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            currentMovement.y += 5 * inGamePhysics.gravity * Time.deltaTime;
            currentMovement.y = 5;
        }
    }
}
