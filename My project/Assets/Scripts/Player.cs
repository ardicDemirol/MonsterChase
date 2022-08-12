using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float maxVelocity = 22f;
    private float movementX;

    [SerializeField]
    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = false;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    public Transform groundCheck;
    public float groundRadius;
    public LayerMask whatIsGround;



    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();  
        sr = GetComponent<SpriteRenderer>();    

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        Debug.Log(IsGrounded());
        PlayerJump();
    }

    private void FixedUpdate()
    {
          
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;

    }

    void AnimatePlayer()
    {
        // we re going to the right side
        if (movementX > 0) 
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0) 
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;

        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isGrounded = false; 
            Debug.Log("Jump Pressed");
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("We landed on ground");
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = false;
            Debug.Log("sadfsd on ground");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
        
    }




}//class
