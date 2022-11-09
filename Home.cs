using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth = 500;
    public HealthBar healthBarBehaive;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);

    }
    public void TakeDamageHome(int amount)
    {
 
        currentHealth -= amount;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);

        //healthBar.fillAmount = currentHealth / maxHealth;
     
        if (currentHealth <= 0)
        {
            DestroyHome();
        }
    }

    private void DestroyHome()
    {
        Destroy(gameObject);
    }
}
