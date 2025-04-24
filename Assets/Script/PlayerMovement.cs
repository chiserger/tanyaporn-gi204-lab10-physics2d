using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector2 moveInput;


    float move;
    [SerializeField] float speed;

    [SerializeField] float jumpForce;
    [SerializeField] bool isJump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0 /*Input.GetAxisRaw("Vertical")*/);
        rb2d.AddForce(moveInput * speed);

        /*        move = Input.GetAxis("Horizontal");
                rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);*/

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }
}
