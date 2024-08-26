using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    // Speed of the character movement
    public float jumpForce = 10f;   // Force of the jump
    [SerializeField] private Rigidbody2D rb;


    public float runSpeed = 10f;


    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movement left and right
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
            //Vector2 moveVelocity = new Vector2(moveSpeed * currentSpeed, rb.velocity.y);
            
           // rb.velocity = moveVelocity;
            
            rb.velocity = new Vector2(-moveSpeed*currentSpeed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : moveSpeed;
            //Vector2 moveVelocity = new Vector2(moveSpeed * currentSpeed, rb.velocity.y);
           // rb.velocity = moveVelocity;
            rb.velocity = new Vector2(moveSpeed*currentSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Stop moving when no key is pressed
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}









