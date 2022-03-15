using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	
	public HealthBar healthBar;

	public Animator animator;
	
	public static int health = 50;

	public GameObject deathEffect;

	public void TakeDamage(int damage)
	{
		health -= damage;
		SoundManagerScript.PlaySound("hit");
		StartCoroutine(DamageAnimation());
		healthBar.SetHealth(health);
		if (health <= 0)
		{
			SoundManagerScript.PlaySound("dead");
			Die();
		}
	}

	void Die()
	{
		animator.SetBool("Defeat", true);
	
		GetComponent<Collider2D>().enabled = true;
	
		this.enabled = false;
		
		StartCoroutine(LoadScene());
		
	}
	
	IEnumerator LoadScene()
     {
         yield return new WaitForSeconds(1.0f);
		//Move to next level0
		Level.CurrentLevel = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene("GameOver");
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	IEnumerator DamageAnimation()
	{

		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

}
