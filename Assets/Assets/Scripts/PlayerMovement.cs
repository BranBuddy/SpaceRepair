using Bran;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private InGamePhysics inGamePhysics;

    [SerializeField] private InputReader input;

    [SerializeField] private float speed;

    internal Vector2 moveDirection;

    //GroundCheck Variables
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    void Start()
    {
        inGamePhysics = GetComponent<InGamePhysics>();
        characterController = GetComponent<CharacterController>();

        input.MoveEvent += HandleMove;
    }

    // Update is called once per frame
    public void Update()
    {
        Move();
    }

    private void HandleMove(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Move()
    {
        if (moveDirection == Vector2.zero)
        {
            return;
        }

        transform.position += new Vector3(moveDirection.x, 0, moveDirection.y) * (speed * Time.deltaTime);
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
