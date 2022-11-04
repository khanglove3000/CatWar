using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public  int currentHealth;
    public int maxHealth = 50;
    public HealthBar healthBarBehaive;
    public CatMovement catMovement;

    public Transform hitPoint;
    public GameObject damageNumber;


    private void Start()
    {
        currentHealth = maxHealth;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);

    }

    public void Damage(int amount)
    {   
            
        this.currentHealth -= amount;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);
        DamagePopup.Create(hitPoint.position, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Damage(10);
            //var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            //clone.GetComponent<FloatingNumber>().damageNumber = this.currentHealth;
            DamagePopup.Create(hitPoint.position, 10);
            catMovement.ToHit();
            StartCoroutine(WaikForIdle());
     
        }
    }
    IEnumerator WaikForIdle()
    {
        yield return new WaitForSeconds(0.5f);
        catMovement.StopRun();
    }

}
