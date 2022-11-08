using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatWarEnum;

public class CatMovement : MonoBehaviour
{

    public CatController catController;
    [SerializeField] float _speed = 1f;
    [SerializeField] Animator animator;
    public SpriteRenderer spriteRenderer;
    public CatType catType;
    public bool isEnemy = true;

    IEnumerator actionCat;

    [Button]
    void PressToRun()
    {
        Run();
    }
    [Button]
    void PressToStopRun()
    {
        StopRun();
    }

    public void Run() {
        if (actionCat != null) {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        actionCat = Movement();
        StartCoroutine(actionCat);
    }

    IEnumerator Movement()
    {
        Vector3 _temp = new Vector3();
        if (catType == CatType.me && !isEnemy)
        {
            _temp = Vector3.right;
        }
        else
        {
            spriteRenderer.flipX = true;
            _temp = Vector3.left;
        }
        animator.SetFloat("run", 1);
  
        while (true)
        {
            transform.Translate(_temp * _speed * Time.deltaTime);
            yield return null;
        }
    }

    public void StopRun() {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetFloat("run", -1);

    }

    public void ToAttack(int damage)
    {
        if (actionCat != null)
        {
                StopCoroutine(actionCat);
                actionCat = null;
        }
        animator.SetTrigger("Attack");
        //catController.CatHealth.TakeDamage(damage);
    }

    public void ToHit()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        //animator.SetBool("hit", true);
    }
}
