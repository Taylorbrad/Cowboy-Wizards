using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public SpriteRenderer sprite;
    public SpriteRenderer flash;

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

        Vector3 pos = transform.rotation.eulerAngles;

        if(91 < pos.z && pos.z < 265){
            sprite.flipY = true;
            flash.flipY = true;
        }
        else
        {
            sprite.flipY = false;
            flash.flipY = false;
        }

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rb.velocity = moveVec * moveSpeed;
    }
}
