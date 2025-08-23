using Bran;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private InGamePhysics inGamePhysics;
    private InputReader input;

    [SerializeField] private float speed;

    internal Vector3 currentMovement = Vector3.zero;

    //GroundCheck Variables
    private Vector3 boxSize = new Vector3(.8f, .1f, .8f);
    public float maxDistance;
    public LayerMask layerMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        input = InputReader.Instance;
        inGamePhysics = GetComponent<InGamePhysics>();
    }

    // Update is called once per frame
    public void Update()
    {
        Move();
    }

    
    private void Move()
    {

        Vector3 horizontalMovement = new Vector3(input.MoveInput.x, 0, input.MoveInput.y);
        Vector3 worldDirection = transform.TransformDirection(horizontalMovement);
        worldDirection.Normalize();

        currentMovement.x = worldDirection.x * speed;
        currentMovement.z = worldDirection.z * speed;

       characterController.Move(currentMovement * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance, boxSize);
    }

    public bool GroundCheck()
    {
        if (Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, layerMask))
        {
            Debug.Log("Yes");

            return true;
        }
        else
        {


            return false;
        }
    }
}
