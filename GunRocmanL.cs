using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRocmanL : MonoBehaviour
{
	public Player controller;
	public Animator animator;
	Rigidbody2D rb2d;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal");
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	void FixedUpdate()
	{
		// การย้ายตัวPlayer
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
	}
}
