using Bran;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField] private float mouseSens = 2.0f;
    [SerializeField] private float upDownRange = 80.0f;
    private float verticalRotation;

    public Camera mainCamera;

    void Start()
    {
        inGamePhysics = GetComponent<InGamePhysics>();
        characterController = GetComponent<CharacterController>();
        input = InputReader.Instance;
        
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        Move();
        Rotation();
    }
  
    private void Rotation()
    {
        float mouseXRotation = input.LookInput.x * mouseSens;
        transform.Rotate(0, mouseXRotation, 0);

        verticalRotation -= input.LookInput.y * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
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


            return true;
        }
        else
        {


            return false;
        }
    }
}
