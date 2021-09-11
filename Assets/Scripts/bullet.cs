using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

  public int timeToLive;
  public Transform bulletTransform;
  public LayerMask enemyLayer;
  public Collider2D bulletCollider;
  //public bool canPierce;
  public int pierce;
  private int pierceAmt;
  public int damage;

  bool dieOrNo;
    // Start is called before the first frame update
    void Start()
    {
      if (gameObject.name.Contains("(Clone)"))
      {
        dieOrNo = true;
      }
      else
      {
        dieOrNo = false;
      }

      pierceAmt = pierce;
    }

    // Update is called once per frame
    void Update()
    {
      bulletTransform.Translate(Time.deltaTime*20,0,0);

      //if (pierceAmt > 0)
      //{
      //  Collider2D[] hitEnemies = DetectLayerCollision(bulletTransform, (float).5, enemyLayer);

      //  damageEnemies(hitEnemies, 10);
      //}


      if (dieOrNo)
      {
        --timeToLive;
      }

        if (timeToLive < 1 && dieOrNo)
        {
          Destroy(gameObject);
        }
    }

    private void damageEnemy(Collider2D enemy, int inDamage)
    {
      enemy.GetComponent<Enemy>().TakeDamage(inDamage);
      Debug.Log("Enemy Hit! here");
    }
/*

*/
    void OnTriggerEnter2D(Collider2D collidedWith)
    {
      if (pierceAmt != 0)
      {
        if (bulletCollider.IsTouchingLayers(enemyLayer))
        {
          damageEnemy(collidedWith, damage);
          pierceAmt--;
        }




      }
      if (pierceAmt  == 0 && dieOrNo)
      {
        Destroy(gameObject);
      }

    }
}
