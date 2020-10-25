using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Animator anmin;
    SpriteRenderer sr;
    

    [SerializeField] float speed = 1; //เรียกใช้ในคลาสนี้เท่าไรเพื่อให้ค่าในอินสเป็กได้และสามารถลากจากunityได้
    [SerializeField] Transform Player;
    [SerializeField] float closeDisTance = 1f;
    [SerializeField] float longDistance = 3f;

    float distanToPlayer = Mathf.Infinity; //เป็นค่าระยะห่าง

    // Start is called before the first frame update
    void Start()
    {
        anmin = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
       // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        distanToPlayer = Vector3.Distance(Player.position, transform.position);// ไว้หาระยะห่างplayerกับNpc
        if (distanToPlayer <= longDistance)
        {
            anmin.Play("NPC1");
            sr.flipX = true;

            if (distanToPlayer <= closeDisTance)
            {
                anmin.Play("NPC1");
                sr.flipX = false;

                FollowPlayer();//ฟังชั่นไล่ตามผู้เล่น
            }

        }
        else
        {
            anmin.Play("NPC1");
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);//MoveTowards คือเคลื่อนที่ไปข่้าวหน้าเข้าหาผู้เล่น
    }
    private void OnDrawGizmosSelected() //ใช้ดูระยะที่ดีเทค
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDisTance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }

   
}
