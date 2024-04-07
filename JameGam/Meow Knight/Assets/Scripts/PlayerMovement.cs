using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public AudioSource jumpSound;
	public AudioSource damageSound;
	public AudioSource deathSound;
	public Transform playerTransform;

	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public int health = 100;
	int damage = 0;
	bool dead = false;


	// Update is called once per frame
	void Update () {

		if(dead)
		{
			return;
		}
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jumpSound.Play();
			animator.SetBool("IsJumping", true);
			jump = true;
			Invoke("Jump", 0.5f);

		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		if (playerTransform.position[1] <= -40f)
		{
			Die();
		}

	}

	void TakeDamage()
	{
		damageSound.Play();
		animator.SetBool("IsDamaged", false);
		health -= damage;
		if(health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		deathSound.Play();
		dead = true;
		animator.SetBool("IsDead", true);
		Invoke("KillPlayer", 5f);
		//do stuff to end game
	}
	void KillPlayer()
	{
		Destroy(gameObject);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

	}

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
		if(dead)
		{
			return;
		}
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
			animator.SetBool("IsDamaged", true);
			damage = enemy.damage;
			Invoke("TakeDamage", 0.5f);
        }
		if (hitInfo.tag == "Chest")
		{
			if(!hitInfo.GetComponent<PowerUp>().isTaken)
			{
				runSpeed += 20f;
			}
			hitInfo.GetComponent<PowerUp>().isTaken = true;
		}
    }

	public void OnLanding ()
	{
	}
	void Jump()
	{
		animator.SetBool("IsJumping", false);
		jump = false;
	}

	public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
