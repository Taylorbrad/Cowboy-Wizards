using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isDead;

    public int maxHealth;
    public int currentHealth;
    public int damageToDeal;

    public HealthBar enemyHealthBar;
    public Transform enemyTransform;

    public LayerMask playerLayer;


    void Start()
    {
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

      Collider2D[] playerHit = Physics2D.OverlapCircleAll(enemyTransform.position, (float).5, playerLayer);

      damagePlayer(playerHit, damageToDeal);
    }


    public void TakeDamage(int damage)
    {
      currentHealth -= damage;
      enemyHealthBar.GetComponent<HealthBar>().SetHealth(currentHealth);

      if (currentHealth < 1)
      {
        currentHealth = 0;
        isDead = true;
      }
    }


    private void damagePlayer(Collider2D[] playerToDamage, int damage)
    {
      foreach(Collider2D player in playerToDamage)
      {
        if (!player.GetComponent<Player>().isDead && !player.GetComponent<Player>().isInvincible)
        {
          player.GetComponent<Player>().TakeDamage(damage);
          Debug.Log("Player Hit!");
        }
      }
    }


    private Collider2D[] DetectLayerCollision(/*Transform collisionPoint, float collisionRadius, LayerMask layerToCollide*/)
    {
      return Physics2D.OverlapCircleAll(enemyTransform.position, (float).5, playerLayer);
    }
}
