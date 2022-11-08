using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack: MonoBehaviour
{
    public float speed = 70f;

    public CatController catController;
	public int attackDamage = 20;
    public CatMovement catTarget;

    private void FixedUpdate()
    {
        if (catTarget)
        {
            catController.catMovement.StopRun();
        }
        else
        {
            catController.catMovement.Run();
        }
    }
    
    void Attack()
    {
        catController.catMovement.ToAttack(attackDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cat" && !catController.catMovement.isEnemy)
        {
            // cần chỉnh lại
            catTarget = collision.gameObject.GetComponent<CatMovement>();
            // Tạo class character để cho những class con kế thừa
            // thay đổi tag thành character

            //StartCoroutine(AttackAction());
            //catController.catMovement.StopRun();
            //catController.catMovement.ToAttack(attackDamage);

        }

        if (collision.gameObject.tag == "Enemy" && catController.catMovement.isEnemy)
        {
            catTarget = collision.gameObject.GetComponent<CatMovement>();
           
        }
    }

}
