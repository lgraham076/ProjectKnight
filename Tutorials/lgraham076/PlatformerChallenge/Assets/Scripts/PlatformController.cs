using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
    public bool facingRight = true;
    public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rgdb;
	
	void Awake () {
        anim = GetComponent<Animator>();
        rgdb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
	}

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h));

        if(h * rgdb.velocity.x < maxSpeed)
        {
            rgdb.AddForce(Vector2.right * h * moveForce);
        }
        if (Mathf.Abs(rgdb.velocity.x) > maxSpeed)
        {
            rgdb.velocity = new Vector2(Mathf.Sign(rgdb.velocity.x) * maxSpeed, rgdb.velocity.y);
        }
        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else if(h < 0 && facingRight)
        {
            Flip();
        }

        if(jump)
        {
            anim.SetTrigger("Jump");
            rgdb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
