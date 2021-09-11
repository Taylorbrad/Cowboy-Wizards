using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public bool isDead;
  public bool isInvincible;

  public int maxHealth;
  public int currentHealth;
  public int setInvincibleFrames;
  public int invincibilityFrames;

  public HealthBar playerHealthBar;
  public SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      if (invincibilityFrames > 0)
      {
        --invincibilityFrames;
        if (((invincibilityFrames % 45) == 0))
        {
          playerSprite.enabled = !playerSprite.enabled;
        }
      }
      else
      {
        isInvincible = false;
        playerSprite.enabled = true;
      }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        playerHealthBar.GetComponent<HealthBar>().SetHealth(currentHealth);
        invincibilityFrames = setInvincibleFrames;
        isInvincible = true;

        if (currentHealth < 1)
        {
          currentHealth = 0;
          isDead = true;
          Debug.Log("I DIDE");
        }
    }
}
