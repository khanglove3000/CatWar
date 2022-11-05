using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapoon : MonoBehaviour
{
	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	[SerializeField] CatMovement catTarget;
	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		ToAttack();
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

	public void ToAttack()
	{
		if (catTarget)
			catTarget.health.Damage(attackDamage);
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<Health>().Damage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
