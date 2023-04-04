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

        UpdateAnimation();


        
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
