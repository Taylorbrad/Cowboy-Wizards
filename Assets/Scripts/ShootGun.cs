using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShootGun : MonoBehaviour
{

    public SpriteAnimator flashAnimation;
    public SpriteRenderer flash;
    public SpriteRenderer bullet;
    public Rigidbody2D bulletRB;
    public Transform bulletPos; //pos meaning position
    public Transform gunPos;
    public Transform playerPos;
    //public int travelTimeSet = 700;
    //public int travelTime;
    public GameObject bulletPoint;

    private Camera cam;
    private Vector3 mousePos;

    void Start()
    {
      cam = Camera.main;
      //travelTime = 0;
    }

    void Update()
    {
        mousePos = Input.mousePosition;
/*
*/
        if(!flashAnimation.isPlaying){
            flash.enabled = false;
            flashAnimation.Play("Idle");
        }

        if (Input.GetMouseButtonDown(0)){
            //float angle = GetAngleFromPlayerToMouse();

            bulletPos.rotation = gunPos.rotation;
            bullet.enabled = true;
            bulletPos.position = gunPos.position;
            //bulletRB.velocity = new Vector2(1,1);
            Rigidbody2D duplicateBullet = Instantiate(bulletRB);
            //duplicateBullet.getComponent(bullet).dieOrNo = true;
            bullet.enabled = false;
            //duplicateBullet.velocity = new Vector2(angle/10,(-(Math.Abs(angle)-90))/10);
            //travelTime = travelTimeSet;
            flash.enabled = true;
            flashAnimation.Play("Shoot");
            //Debug.Log(gunPos.rotation.eulerAngles[2]);
            //Debug.Log(angle);
            //bulletPos.rotation = gunPos.rotation;
            //bulletPos.Rotate(0,0,-(bulletPos.rotation.eulerAngles[2]) + -(angle) -90);
            //Debug.Log(gunPos.rotation.eulerAngles[2]);
            //bulletPos.Rotate(0,0,gunPos.rotation.eulerAngles[2]);
            //bulletRB.velocity = new Vector2(10,0);
            }
/*
        if (travelTime == 0)
        {

          bullet.enabled = false;
          bulletRB.velocity = Vector2.zero;
          bulletPos.position = playerPos.position;
          //bulletPos.rotation = gunPos.rotation;
          // bulletPos.x = new Vector2(0,0)[1];
        }
        */
        //else
    }


/*
    public float GetAngleFromPlayerToMouse()
    {
      Vector3 mousePosWorld = cam.ScreenToWorldPoint(new Vector3(mousePos[0],mousePos[1], cam.nearClipPlane));
      Vector2 playerPosVec = playerPos.position;
      float deltaX = mousePosWorld[0] - playerPosVec[0];
      float deltaY = mousePosWorld[1] - playerPosVec[1];
      return (Mathf.Atan2(deltaX, deltaY) * 180/Mathf.PI);
    }
*/
}
