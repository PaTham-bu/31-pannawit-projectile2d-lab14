using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb2d;
    Vector2 moveInput;

    [SerializeField] float speed; // public variable use Pascal casing
    float move;         // private variable

    [SerializeField] public float JumpForce;
    [SerializeField] public bool IsJumping;

    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * speed);


        /*move = Input.GetAxis("Horizontal"); // x - axis

        // use rigidbody2d to move left and right (x-axis)
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);*/

        // jump
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, JumpForce));

            Debug.Log("Jump"); // for debugging purpose
        }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }



}