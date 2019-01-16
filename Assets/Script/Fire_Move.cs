using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Fire_Move : MonoBehaviour {

	float dirX, dirY, rotateAngle;
	[SerializeField]
	float moveSpeed = 2f;
	[SerializeField]
	float bulletSpeed = 5f;

	[SerializeField]
	Transform gun;
	[SerializeField]
	Rigidbody2D bullet;
	// Use this for initialization
	void Start () {
		rotateAngle = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Fire();
		Rotate();
	}
	void Move(){
		dirX = Mathf.RoundToInt(CrossPlatformInputManager.GetAxis("Horizontal"));
		dirY = Mathf.RoundToInt(CrossPlatformInputManager.GetAxis("Vertical"));

		transform.position = new Vector2(dirX * moveSpeed * Time.deltaTime + transform.position.x, dirY * moveSpeed * Time.deltaTime + 
		transform.position.y);
	}

	void Fire(){
		if(CrossPlatformInputManager.GetButtonDown("Fire1")){
			var firedBullet = Instantiate(bullet, gun.position, gun.rotation);
			firedBullet.AddForce(gun.up * bulletSpeed);
		}
	}

	void Rotate(){
		if(dirX == 0 && dirY == 1){
			rotateAngle = 0;
		}

		if(dirX == 1 && dirY == 1){
			rotateAngle = -45f;
		}

		if(dirX == 1 && dirY == 0){
			rotateAngle = -90f;
		}

		if(dirX == 1 && dirY == -1){
			rotateAngle = -135f;
		}

		if(dirX == 0 && dirY == -1){
			rotateAngle = -180f;
		}

		if(dirX == -1 && dirY == -1){
			rotateAngle = -225f;
		}

		if(dirX == -1 && dirY == 0){
			rotateAngle = -270f;
		}

		if(dirX == -1 && dirY == 1){
			rotateAngle = -315f;
		}

		gun.rotation = Quaternion.Euler(0f, 0f, rotateAngle);
	}
}
