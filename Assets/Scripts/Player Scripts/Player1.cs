using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private Rigidbody2D mybody;
    private float movementX;
    private float movementY;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string JUMP_ANIMATION = "Jump";
    private string GROUND_TAG = "Ground";
    private bool isGrounded;

    void Awake()
    {

        mybody = GetComponent<Rigidbody2D>();
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
        PlayerMoveKeyBoard();
        AnimatedPlayer();
        PlayerJump();
    }

    void FixedUpdate()
    {

    }

    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        //movementY = Input.GetAxisRaw("Vertical");

        //Vector3 movement = new Vector3(movementX, 0.0f, 0.0f);
        //mybody.velocity = movement * moveForce;
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        transform.position += new Vector3(0f, movementY, 0f) * Time.deltaTime * jumpForce;
    }


    void AnimatedPlayer()
    {
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

    void PlayerJump()
    {
 
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SoundManagerScript.PlaySound("jump");
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
            isGrounded = false;
        }
    }

    void BackToIdle()
    {
        isGrounded = true;
        anim.SetBool(JUMP_ANIMATION, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            BackToIdle();
        }


    }

    

}
