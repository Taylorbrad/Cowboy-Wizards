using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{

    public SpriteAnimator flashAnimation;
    public SpriteRenderer flash;
    public SpriteRenderer bullet;
    public Rigidbody2D bulletRB;
    public Transform bulletPos; //pos meaning position
    public Transform gunPos;
    public int travelTimeSet = 700;

    public int travelTime;

    void Start()
    {
      travelTime = 0;
    }

    void Update()
    {

        if (travelTime > 0)
        {
          travelTime--;
          bulletPos.position += new Vector3((float).1,0);
        }

        if(!flashAnimation.isPlaying){
            flash.enabled = false;
            flashAnimation.Play("Idle");
        }

        if (Input.GetMouseButtonDown(0) && travelTime == 0){
            travelTime = travelTimeSet;
            flash.enabled = true;
            flashAnimation.Play("Shoot");
            bullet.enabled = true;
            //bulletRB.velocity = new Vector2(10,0);
            }

        if (travelTime == 0)
        {
          bullet.enabled = false;
          bulletRB.velocity = Vector2.zero;
          bulletPos.position = new Vector3((float).8,(float).063);
          //bulletPos.rotation = gunPos.rotation;
          // bulletPos.x = new Vector2(0,0)[1];
        }
        //else
    }

}
