using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 50;

    public HealthBar healthBarBehaive;
    public Transform hitPoint;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);

    }

    public void TakeDamage(int amount)
    {

        this.currentHealth -= amount;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);
        DamagePopup.Create(hitPoint.position, currentHealth);
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }


    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    //IEnumerator WaikForIdle()
    //{
    //    yield return new WaitForSeconds(0.5f);
       
    //}

}
