using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private float move;
    private CapsuleCollider2D coll;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask jumpableEnemy;
    [SerializeField] private LayerMask jumpableBlock;

    [Header("Wall Jump System")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;




    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if((Input.GetButtonDown("Jump")) && ((IsGrounded()) || (IsEnemyHead()) || (IsMoveBlock())))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }

        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.05f, 0.8f), 0, jumpableGround);
        if(isWallTouch && IsGrounded() != true && move != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }

        UpdateAnimation();


        
    }


    private void FixedUpdate()
    {
        if (isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }

    private void UpdateAnimation()
    {
        if (move > 0f)
        {
            sprite.flipX = false;
        }
        else if (move < 0f)
        {
            sprite.flipX = true;
        }
        else
        {

        }
    }






    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private bool IsEnemyHead()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableEnemy);
    }

    private bool IsMoveBlock()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableBlock);
    }

}
