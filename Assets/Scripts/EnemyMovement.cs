using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D myRigidBody;
    private bool moving;
    private bool dying;
    public int health;
    public SpriteAnimator spriteAnimator;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        myRigidBody = GetComponent<Rigidbody2D>();

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVec = Vector2.zero;

        if (moveVec.magnitude > 1)
        {
            moveVec = moveVec.normalized;
        }

        if (!dying)
        {
            if (moving)
            {
                spriteAnimator.Play("Walk");
                timeToMoveCounter -= Time.deltaTime;
                myRigidBody.velocity = moveDirection;

                if (timeToMoveCounter < 0f)
                {
                    moving = false;
                    //timeBetweenMoveCounter = timeBetweenMove;
                    timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                }
            }
            else
            {
                spriteAnimator.Play("Idle");
                timeBetweenMoveCounter -= Time.deltaTime;
                myRigidBody.velocity = Vector2.zero;

                if (timeBetweenMoveCounter < 0f)
                {
                    moving = true;
                    timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

                    moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                    if (moveDirection.x != 0)
                    {
                        spriteAnimator.FlipTo(moveDirection.x);
                    }
                }
            }
        }
        if (!spriteAnimator.isPlaying)
        {
            dying = false;
            RemoveEnemy();
        }
    }

    public void Death(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            myRigidBody.velocity = Vector2.zero;
            dying = true;
            spriteAnimator.Play("Death");
        }
    
    }

    public void RemoveEnemy()
    {
        myRigidBody.gameObject.SetActive(false);
    }
}
