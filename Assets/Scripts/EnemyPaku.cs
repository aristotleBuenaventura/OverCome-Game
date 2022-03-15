using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaku : MonoBehaviour
{
	public Animator animator;

	public int maxHealth = 100;
	int currentHealth;

	void Start()
	{
		currentHealth = maxHealth;
		
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		//animator.SetTrigger("Hurt");
		animator.SetBool("Hit", true);

		if (currentHealth <= 0)
		{
			Die();

		}
	}

	void Die()
	{
		animator.SetBool("Death", true);

		GetComponent<Collider2D>().enabled = true;
		
		this.enabled = false;
        StartCoroutine(ExampleCoroutine());
        Destroy(gameObject, 1);
    }

	IEnumerator ExampleCoroutine()
	{
		//Print the time of when the function is first called.
		//Debug.Log("Started Coroutine at timestamp : " + Time.time);

		//yield on a new YieldInstruction that waits for 5 seconds.
		yield return new WaitForSeconds(5f);

		//After we have waited 5 seconds print the time again.
		//Debug.Log("Finished Coroutine at timestamp : " + Time.time);
	}
}
