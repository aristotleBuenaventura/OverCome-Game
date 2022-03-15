using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPotion : MonoBehaviour
{
	public HealthBar healthBar;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			SoundManagerScript.PlaySound("collect");
			Debug.Log(PlayerHealth.health);
			PlayerHealth.health += 20;
			healthBar.SetHealth(PlayerHealth.health);
			Destroy(gameObject);
			
		}
	}
}
