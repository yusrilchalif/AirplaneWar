using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acceloMove : MonoBehaviour {

	Rigidbody2D rb;
	float dirX;
	float moveSpeed = 15f;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.acceleration.x * moveSpeed;
		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -3.0f, 3.0f), transform.position.y);
		Debug.Log("Pesawat Bergerak");
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(dirX, 0f);
	}
}
