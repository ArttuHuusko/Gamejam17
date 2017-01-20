﻿using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

	public Rigidbody2D rig;
	public float moveSpeed = 0;
	public float maxSpeed = 10;
	public float acceleration = 10;
	public float deceleration = 10;
	public float turnSpeed = 0;
	public float maxTurnSpeed = 0;
	// Use this for initialization
	void Start () 
	{
		rig = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		turnSpeed = moveSpeed / 2;
		if (Input.GetKey (KeyCode.UpArrow) && (moveSpeed < maxSpeed)) {
			moveSpeed = moveSpeed + acceleration * Time.deltaTime;
		} 
		else
		{
			if (moveSpeed > deceleration * Time.deltaTime)
				moveSpeed = moveSpeed - deceleration * Time.deltaTime;
			else
				moveSpeed = 0;
		}
			
		
		transform.position += transform.up * Time.deltaTime * moveSpeed;
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			transform.Rotate (Vector3.forward * turnSpeed);
		}
		if (Input.GetKey(KeyCode.RightArrow)) 
		{
			transform.Rotate (Vector3.forward * -turnSpeed);
		}
	}
}
