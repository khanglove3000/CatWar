using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CatWarEnum;

public class CatController : MonoBehaviour
{
	[Header("Health")]
    public int currentHealth;
    public int maxHealth = 100;
    public HealthBar healthBarBehaive;
    public Transform hitPoint;
    public bool isDead = false;

    [Header("Movement")]
    public CatController catController;
    [SerializeField] float _speed = 1f;
    [SerializeField] Animator animator;
    public SpriteRenderer spriteRenderer;

    public CatType catType;
    IEnumerator actionCat;

    [Header("Attack")]
    public int attackDamage = 5;
    public CatController catTarget;
    public Home homeTarget;
    //[Header("Unity Stuff")]
    //public Image healthBar;
    

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);

    }
    private void FixedUpdate()
    {
        if (catTarget || homeTarget)
        {
            StopRun();
        }
        else
        {
            Walk();
        }
    }

    public void TakeDamage(int amount)
    {
        ActiveAnimationHit();
        currentHealth -= amount;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);
       
        //healthBar.fillAmount = currentHealth / maxHealth;
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
    public void Walk()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        actionCat = Movement();
        StartCoroutine(actionCat);
    }

    IEnumerator Movement()
    {
        Vector3 _toward = new Vector3();
        if (catType == CatType.me)
        {
            _toward = Vector3.right;
        }
        else
        {
            spriteRenderer.flipX = true;
            _toward = Vector3.left;
        }
        ActiveAnimationWalk();
        while (true)
        {
            transform.Translate(_toward * _speed * Time.deltaTime);
            yield return null;
        }
    }

    public void StopRun()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetFloat("Run", -1);

    }
    public void ActiveAnimationWalk()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetFloat("Run", 1);
    }

    public void ActiveAnimationAttack()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }

        animator.SetTrigger("Attack");
        //animator.SetInteger("AttackByInt", 1);
    }
    
    public void ActiveAnimationHit()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetTrigger("Hit");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(catType == CatType.me && collision.gameObject.tag == "Player")
        {
            catTarget = collision.gameObject.GetComponent<CatController>();
            ToAttack();
        }

        if (catType == CatType.player && collision.gameObject.tag == "Me")
        {
            // cần chỉnh lại
            catTarget = collision.gameObject.GetComponent<CatController>();
            ToAttack();
            // Tạo class character để cho những class con kế thừa
            // thay đổi tag thành character
        }

        if (catType == CatType.me && collision.gameObject.tag == "HomePlayer")
        {
            homeTarget = collision.gameObject.GetComponent<Home>();

        }

        if (catType == CatType.player && collision.gameObject.tag == "HomeMe")
        {
            
        }
    }

    void ToAttack()
    {
        if (catTarget)
        {
            ActiveAnimationAttack();
            TakeDamage(attackDamage);
        }

        if (homeTarget)
        {
            ActiveAnimationAttack();
            homeTarget.TakeDamageHome(attackDamage);
        }
    }

        
}
