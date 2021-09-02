using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public SpriteAnimator spriteAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = Vector2.zero;
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");

        if(moveVec.magnitude > 1)
        {
            moveVec = moveVec.normalized;
        }

        rb.velocity = moveVec * moveSpeed;

        if(moveVec != Vector2.zero)
        {   
            spriteAnimator.Play("Walk");
        }
        else
        {
            spriteAnimator.Play("Idle");
        }

        if(moveVec.x != 0)
        {
            spriteAnimator.FlipTo(moveVec.x);
        }
    }
}
