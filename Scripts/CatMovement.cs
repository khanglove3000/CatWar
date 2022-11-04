using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CatWarEnum;

public class CatMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] Animator animator;
    public Health health; 
    public CatType catType;

    IEnumerator actionCat;
    [Button] void Run() {
        animator.SetBool("attack", false);
        StartRun();
    }
    [Button] void Idle() {
        StopRun();
        animator.SetFloat("speed", 0);
    }
    [Button]
    void Attack()
    {
        StopRun();
        ToAttact();
    }
    [Button]
    void Hit()
    {
        StopRun();
        ToHit();
    }


    IEnumerator Movement()
    {
        Vector3 _temp = new Vector3();
        if (catType == CatType.me) {
            _temp = Vector3.right;
        }
        else
            _temp = Vector3.left;
        animator.SetFloat("speed", _speed);
        while (true) {
            transform.Translate(_temp * _speed * Time.deltaTime);
            yield return null;
        }
    }
    public void StartRun() {
        if (actionCat != null) {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        actionCat = Movement();
        StartCoroutine(actionCat);
    }
    public void StopRun() {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetFloat("speed", 0);
        animator.SetBool("attack", false);
        animator.SetBool("hit", false);
    }

    public void ToAttact()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetBool("attack", true);
    }

    public void ToHit()
    {
        if (actionCat != null)
        {
            StopCoroutine(actionCat);
            actionCat = null;
        }
        animator.SetBool("hit", true);
    }

}
