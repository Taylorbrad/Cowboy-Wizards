using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isDead;

    public int maxHealth;
    public int currentHealth;

    public HealthBar enemyHealthBar;


    void Start()
    {
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(int damage)
    {
      currentHealth -= damage;
      enemyHealthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
    }
}
