using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    private float attackCooldown = 1f;

   
    [SerializeField] CatMovement myCat;
    [SerializeField] CatMovement catTarget;

  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            catTarget = collision.gameObject.GetComponent<CatMovement>();
            //StartCoroutine(AttackAction());
        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        /*check nếu cứ có collider mang tag "Cat" thì đánh*/
        if(collision.gameObject.tag == "Cat")
        {
            StartCoroutine(AttackAction());
            StartCoroutine(AttackCoroutine());
        }
  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*Đánh đối thủ chết rồi thì dừng anim attack, move tiếp*/
    }
    IEnumerator AttackAction() {
        /*stop move*/
        myCat.StopRun();
        /*Start anim attack*/
        Attack();
        /*Waik anim attack finish thi*/

        /*số máu văng ra là bao nhiêu*/

        yield return null;
    }
    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
    }
    void Attack()
    {
        if (catTarget)
            catTarget.health.Damage(damage);
    }
}
