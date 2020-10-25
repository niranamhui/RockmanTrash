using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool isInvulnerable = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gum"))
        {
            TakeDamage(40);
        }
    }
    //void Update()
   // {
       // if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
           // TakeDamage(40);
       // }
  //  }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    // Start is called before the first frame update
    public void Damage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 0)
        {
            string Deat = DieMoter(maxHealth);
            print(Deat);
        }
    }

    string DieMoter(int Deatmous)
    {
        Deatmous = maxHealth;
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }

        return "Deatmous";
    }

    
}
