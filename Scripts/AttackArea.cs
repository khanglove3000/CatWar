using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    private float attackCooldown = 1f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    protected bool isAttack = false;
   
    [SerializeField] CatMovement myCat;
    [SerializeField] CatMovement catTarget;

    private void Update()
    {
        if (catTarget == null) return;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            // cần chỉnh lại
            catTarget = collision.gameObject.GetComponent<CatMovement>();
            // Tạo class character để cho những class con kế thừa
            // thay đổi tag thành character

            //StartCoroutine(AttackAction());

        }
    }
    private void OnTriggerStay2D(Collider2D collision){
        /*check nếu cứ có collider mang tag "Cat" thì đánh*/
        if(collision.gameObject.tag == "Cat")
        {
            
            StartCoroutine(AttackAction());
        }

    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        /*Đánh đối thủ chết rồi thì dừng anim attack, move tiếp*/
    }
    IEnumerator AttackAction() {
        /*stop move*/
        myCat.StopRun();
        isAttack = true;
        /*Start anim attack*/
        if(isAttack)
            Attack();
        /*Waik anim attack finish thi*/

        /*số máu văng ra là bao nhiêu*/

        yield return null;
    }
    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
    }
   public void Attack()
    {
        //if (catTarget)
        //    catTarget.catHealth.TakeDamage(damage);
    }
}
