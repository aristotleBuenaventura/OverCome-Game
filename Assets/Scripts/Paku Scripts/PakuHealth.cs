using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PakuHealth : MonoBehaviour
{
	public GameObject smallPotion;
	

	public HealthBar healthBar;

	public Animator animator;

	public int health = 30;

	public GameObject deathEffect;

	public bool isInvulnerable = false;

	public GameObject key;

	

	public void Start()
    {
		smallPotion.SetActive(false);
		key.SetActive(false);
		
	}

	void Update()
    {
		if(PlayerHealth.health <= 20)
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
		
		if (health <= 15)
		{
			GetComponent<Renderer>().material.color = new Color (255, 0, 0);
			GetComponent<PakuAttack>().attackRate = 8f;
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
