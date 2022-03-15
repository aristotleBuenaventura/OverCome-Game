using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSkellyHealth : MonoBehaviour
{
	public GameObject smallPotion;
	public HealthBar healthBar;

	public Animator animator;

	public int health = 140;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public GameObject key;

    public void Start()
    {
		key.SetActive(false);
		smallPotion.SetActive(false);
	}

	void Update()
	{
		if (PlayerHealth.health <= 20)
		{
			smallPotion.SetActive(true);
		}
	}

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		animator.SetBool("Hit", true);

		healthBar.SetHealth(health);

		if (health <= 130)
		{
			GetComponent<ForestSkellyAttack>().attackDamage = 3;
			GetComponent<ForestSkellyAttack>().attackRate = 1.5f;
		}

		if (health <= 80)
		{
			GetComponent<ForestSkellyAttack>().attackDamage = 6;
			GetComponent<ForestSkellyAttack>().attackRate = 2f;
		}

		if (health <= 50)
		{
			GetComponent<Renderer>().material.color = new Color(255, 0, 0);
			GetComponent<ForestSkellyAttack>().attackDamage = 8;
			GetComponent<ForestSkellyAttack>().attackRate = 3f;
		}

		if (health <= 0)
		{
			SoundManagerScript.PlaySound("key");
			key.SetActive(true);
			Die();
		}
	}

	void Die()
	{
		animator.SetBool("Death", true);

		GetComponent<Collider2D>().enabled = true;

		this.enabled = false;

		Destroy(gameObject, 1);
	}

}
