using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class move_fire : MonoBehaviour {

	Rigidbody2D rb;
	float dirX;

	[SerializeField]
	float moveSpeed = 5f, bulletSpeed = 500f;
	bool facingRight = true;
	Vector3 localScale;

	public Transform fire;
	public Rigidbody2D bullet;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//dirX = CrossPlatformInputManager.GetAxis("Horizontal");

		if(CrossPlatformInputManager.GetButtonDown("Fire"))
		{
			Fire();
		}
	}

	void FixedUpdate(){
		//rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
	}

	void Fire(){
		var firedBullet = Instantiate(bullet, fire.position, fire.rotation);
		firedBullet.AddForce(fire.up * bulletSpeed);
	}
}
