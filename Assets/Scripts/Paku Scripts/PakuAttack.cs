using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PakuAttack : MonoBehaviour
{
	public int attackDamage = 2;
	public float attackRate = 0.5f;
	float nextAttackTime = 0f;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	void Update()
	{
		if (Time.time >= nextAttackTime)
		{
				Attack();
				nextAttackTime = Time.time + 1.5f / attackRate;
		}
	}

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
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
