using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public bool isDead;

  public int maxHealth;
  public int currentHealth;

  public HealthBar playerHealthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
      currentHealth -= damage;
      playerHealthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
      if (currentHealth < 1)
      {
        currentHealth = 0;
        isDead = true;
        Debug.Log("I DIDE");
      }
    }
}
