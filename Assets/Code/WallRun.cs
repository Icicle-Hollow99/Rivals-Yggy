using UnityEngine;
using UnityEngine.InputSystem;

public class WallRunInputSystem : MonoBehaviour
{
    public float wallRunForce = 10f;
    public float wallCheckDistance = 1f;
    public float gravityReduction = 4f;

    private Rigidbody rb;
    private bool isWallRunning;
    private bool wallLeft;
    private bool wallRight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForWall();

        // NEW Input System (W key)
        bool holdingForward = Keyboard.current != null && Keyboard.current.wKey.isPressed;

        if ((wallLeft || wallRight) && holdingForward)
        {
            StartWallRun();
        }
        else
        {
            StopWallRun();
        }
    }

    void FixedUpdate()
    {
        if (isWallRunning)
        {
            rb.useGravity = false;

            rb.AddForce(transform.forward * wallRunForce, ForceMode.Force);
            rb.AddForce(Vector3.down * gravityReduction, ForceMode.Force);
        }
    }

    void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, transform.right, wallCheckDistance);
        wallLeft  = Physics.Raycast(transform.position, -transform.right, wallCheckDistance);
    }

    void StartWallRun()
    {
        isWallRunning = true;
    }

    void StopWallRun()
    {
        isWallRunning = false;
        rb.useGravity = true;
    }
}
