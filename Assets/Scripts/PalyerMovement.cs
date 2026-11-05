
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 5f;

    public Rigidbody2D myBody;
    private InputAction moveInput;
    private Vector2 inputForce;

    public Transform groundChecker;
    public float checkSize = 0.1f;
    public LayerMask groundLayer;

    private bool onGround;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        inputForce = moveInput.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        myBody.linearVelocityX = inputForce.x * speed;

        if (inputForce.y > 0 && onGround)
        {
            myBody.linearVelocityY = inputForce.y * jumpPower;
            onGround = false;
        }
        else
        {
            onGround = Physics2D.OverlapCircle(
                groundChecker.position,
                checkSize,
                groundLayer
            );
        }
    }
}
