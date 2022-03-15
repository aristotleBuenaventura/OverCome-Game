using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniHealth : MonoBehaviour
{
	public GameObject largePotion;

	public HealthBar healthBar;

	public Animator animator;

	public int health = 250;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public GameObject gate;
	
	public GameObject gate1;
    public void Start()
    {
		largePotion.SetActive(false);
		gate.SetActive(false);
		gate1.SetActive(true);

    }

	void Update()
	{
		if (PlayerHealth.health <= 45)
		{
			largePotion.SetActive(true);
		}
	}
	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		animator.SetBool("Hit", true);

		healthBar.SetHealth(health);

		if (health <= 230)
		{
			GetComponent<OniAttack>().attackDamage = 2;
			GetComponent<OniAttack>().attackRate = 2f;
		}

		if (health <= 200)
		{
			GetComponent<OniAttack>().attackDamage = 3;
			GetComponent<OniAttack>().attackRate = 2f;
		}

		if (health <= 150)
		{
			GetComponent<OniAttack>().attackDamage = 3;
			GetComponent<OniAttack>().attackRate = 1.5f;
		}

		if (health <= 130)
		{
			GetComponent<OniAttack>().attackDamage = 5;
			GetComponent<OniAttack>().attackRate = 1f;
		}

		if (health <= 120)
		{
			GetComponent<OniAttack>().attackDamage = 3;
			GetComponent<OniAttack>().attackRate = 2f;
		}

		if (health <= 100)
		{
			GetComponent<OniAttack>().attackDamage = 2;
			GetComponent<OniAttack>().attackRate = 1.5f;
		}

		if (health <= 50)
		{
			GetComponent<OniAttack>().attackDamage = 2;
			GetComponent<OniAttack>().attackRate = 2f;
		}



		if (health <= 0)
		{
			SoundManagerScript.PlaySound("open");
			Die();
			StartCoroutine(Gate());
			gate.SetActive(true);
			gate1.SetActive(false);
		}
	}

	void Die()
	{
		animator.SetBool("Death", true);
		
		GetComponent<Collider2D>().enabled = true;

		this.enabled = false;

		Destroy(gameObject, 2);
	}


	IEnumerator Gate()
	{
		yield return new WaitForSeconds(2.0f);
		

	}
}
