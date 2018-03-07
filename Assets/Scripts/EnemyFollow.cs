using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {
	public float Speed;
	private Transform target;
	Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector2.Distance(transform.position, target.position) < 7)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
		}	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			Application.LoadLevel("WIP");
		}
	}
}
