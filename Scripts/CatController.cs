using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatWarEnum;

public class CatController : MonoBehaviour
{
	[Header("Health")]
    public int currentHealth;
    public int maxHealth = 50;
    public HealthBar healthBarBehaive;
    public Transform hitPoint;
    private bool isDead = false;

    [Header("Movement")]
    public CatController catController;
    [SerializeField] float _speed = 1f;
    [SerializeField] Animator animator;
    public SpriteRenderer spriteRenderer;
    public CatType catType;
    public bool isEnemy = true;
    IEnumerator actionCat;

    [Header("Attack")]
    public float speed = 70f;
    public int attackDamage = 20;
    public CatMovement catTarget;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBarBehaive.SetHealth(currentHealth, maxHealth);

    }
    private void FixedUpdate()
    {
        if (catTarget)
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
        if (catType == CatType.me && !isEnemy)
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
        animator.SetFloat("run", -1);

    }
    public void ActiveAnimationWalk()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetFloat("run", 1);
    }

    public void ActiveAnimationAttack(int damage)
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetTrigger("Attack");
        TakeDamage(damage);
    }

    public void ActiveAnimationHit()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        //animator.SetBool("hit", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            Debug.Log("OnTriggerEnter2D");
            // cần chỉnh lại
            catTarget = collision.gameObject.GetComponent<CatMovement>();
            // Tạo class character để cho những class con kế thừa
            // thay đổi tag thành character
            StopRun();
            //StartCoroutine(AttackAction());
            //catController.catMovement.StopRun();
            //catController.catMovement.ToAttack(attackDamage);

        }

        //if (collision.gameObject.tag == "Enemy")
        //{
        //    Debug.Log("OnTriggerEnter2D");
        //    catTarget = collision.gameObject.GetComponent<CatMovement>();
        //    StopRun();
        //}
    }
}
