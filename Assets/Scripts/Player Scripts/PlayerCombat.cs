﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public Animator animator;

	public Transform attackPoint;
	public LayerMask enemyLayers;

	public float attackRange = 1.52f;
	public int attackDamage = 2;
	public float attackRate = 2f;
	float nextAttackTime = 0f;



	void Update()
	{
		if (Time.time >= nextAttackTime)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				SoundManagerScript.PlaySound("attack");
				Attack();
				nextAttackTime = Time.time + 1.5f / attackRate;
			}
		}
	}

	void Attack()
	{
		animator.SetTrigger("Attack");

		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PakuHealth>().TakeDamage(attackDamage);
        }

    }

	void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}