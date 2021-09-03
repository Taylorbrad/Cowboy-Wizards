using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{

    public SpriteAnimator flashAnimation;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(!flashAnimation.isPlaying){
            sprite.enabled = false;
            flashAnimation.Play("Idle");
        }

        if (Input.GetMouseButtonDown(0)){
            sprite.enabled = true;
            flashAnimation.Play("Shoot");
            }
    }

}
