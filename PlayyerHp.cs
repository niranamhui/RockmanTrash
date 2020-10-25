using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayyerHp : MonoBehaviour
{
	public int health = 100;
	public GameObject deathEffect;

	public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
	public bool isInvulnerable = false;
	Animator anime;
	public Text TxteEnd;
	public CRTCoinUsingStatic Startcoin;
	public GameObject END;


	private void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		anime = GetComponent<Animator>();

		END.SetActive(false);

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("hitInfo"))
		{
			TakeDamageHp(20);
			Damage(20);
	
		}

		if (collision.gameObject.CompareTag("TrashRen"))
		{
			TakeDamageHp(100);
			Damage(100);
		}
	}

	void TakeDamageHp(int damage)
	{
		currentHealth -= damage;//เลือดลด
		healthBar.SetHealth(currentHealth);//การแสดงของเลือด
	}

	public void Damage(int damage)
	{

		if (isInvulnerable)
			return;

		health -= damage;
		StartCoroutine(DamageAnimation());//ดาเมจplayer

		if (health <= 0)
		{
			anime.Play("RockmanDeat");

			string condition = Die();
			print (condition);

			END.SetActive(true);
		}
	}
		
	string Die() //ตรวจสอบการตายของPlayer
	{
		GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 2f);
		TxteEnd.text = "END";
		Destroy(Startcoin);
		return ("Deat");
		
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
