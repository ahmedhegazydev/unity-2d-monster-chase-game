using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    private SpriteRenderer spriteRenderer;


    [SerializeField]
    private Rigidbody2D rigidbody2D;


    private Animator animator;


    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private string WALK_ANIMATON = "walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";


    private void Awake()
    {

        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();



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
        PlayerJump();


    }

    void PlayerMoveKeyboard()
    {

        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;


    }

    void AnimatePlayer()
    {
        if (movementX > 0 )
        {
            animator.SetBool(WALK_ANIMATON, true);
            spriteRenderer.flipX = false;

        }
        else
        {
            if(movementX < 0) {
                animator.SetBool(WALK_ANIMATON, true);
                spriteRenderer.flipX = true;

            }
            else
            {
                animator.SetBool(WALK_ANIMATON, false);
            }
        }

    }


    void PlayerJump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("OnCollisionEnter2D");

        }   
    }

}
