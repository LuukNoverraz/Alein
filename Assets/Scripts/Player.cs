using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float moveSpeed = 10.0f;
	public float jumpSpeed = 300.0f;
	public float smoothTimeX = 0.1f;
	public float smoothTimeY = 0.1f;
	GameObject Camera;
	Vector2 cameraVelocity;
	Animator anim;
	Rigidbody2D rigid;

	void Start () {
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody2D> ();
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	
	void Update () {
		float posX = Mathf.SmoothDamp (Camera.transform.position.x, transform.position.x, ref cameraVelocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (Camera.transform.position.y, transform.position.y, ref cameraVelocity.y, smoothTimeY);
		Camera.transform.position = new Vector3 (posX, 0, Camera.transform.position.z);
	}

	void FixedUpdate() {
		float move = Input.GetAxis ("Horizontal");
		rigid.velocity = new Vector2(move * moveSpeed, rigid.velocity.y);
		if (Input.GetButtonDown ("Jump")) {
			rigid.AddForce (Vector2.up * jumpSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Warp")
		{
			Application.LoadLevel("WIP");
		}
		if (col.gameObject.tag == "Death") 
		{
			Application.LoadLevel ("Scene1");
		}
	}
}
