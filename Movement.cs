using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	bool checkPressBtt = false;
	Rigidbody2D rb2d;
	SpriteRenderer sr;
	Animator anime;
	public float speed;
	float xInput, yInput;
	private void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		anime = GetComponent<Animator>();

		bool checkPressBtt = false;

		do
		{
			print("ControlBtton");

		} 
		while (checkPressBtt == true);
		{
			print("ControlBttoff");
		}
	
	}

	private void FixedUpdate()
	{
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
		{
			rb2d.velocity = new Vector2(2, rb2d.velocity.y);
			anime.SetInteger("Rocman", 1);
			sr.flipX = false;
		}
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
		{
			rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
			anime.SetInteger("Rocman", 1);
			//sr.flipX = true;
		}
		

		else if (Input.GetMouseButton(1)) //ยิงปืน
		{
			anime.SetInteger("Rocman", 3);
		}

		


		else if (Input.GetKey(KeyCode.Space))
		{
			anime.SetInteger("Rocman",2);
			rb2d.velocity = new Vector2(rb2d.velocity.x , 3);
		}
		else
		{
			anime.SetInteger("Rocman", 0);//กลับมาท่าเริ่มต้น
			rb2d.velocity = new Vector2(0, rb2d.velocity.y);
		}
		if (checkPressBtt)
		{
			MoveHoirizontall();
		}
	}

	public void RigtPressBtt()
	{
		xInput = speed * 10 * Time.deltaTime;
		sr.flipX = false;
		checkPressBtt = true;
	}

	public void LeftPressBtt()
	{
		xInput = -speed * 10 * Time.deltaTime;
		sr.flipX = true;
		checkPressBtt = true;
	}
	public void JumePressBtt()
	{
		rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
		checkPressBtt = true;
	}
	public void UpBtt()
	{
		checkPressBtt = false;
	}

	public void MoveHoirizontall() //การเคลื่อนที่โดยใช้ปุ่มกด
	{
		transform.Translate(xInput, 0 , 0);

		anime.SetInteger("Rocman", 1);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("coinText"))
		{
			collision.gameObject.SetActive(false);
		}
	}

}
