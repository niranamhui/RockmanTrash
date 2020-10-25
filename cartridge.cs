using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartridge : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2dgum;
    public int damage = 40;
    private void Start()
    {
        rb2dgum.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)//ด้านดาเมจ
    {

        Hp enemy = hitInfo.GetComponent<Hp>();
        if (enemy != null)
        {
            enemy.Damage(damage);
        }
        Destroy(gameObject);
    }

}
