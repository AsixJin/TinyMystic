using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour {
	
	/* This script controls the movement of
	whatever it's attached to.
	*/

	private Rigidbody2D Rigidbody2D;
	public float speed = 5;

	private void Awake(){
		Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if (Input.GetButton(ControlConst.DPAD_UP)){
			Rigidbody2D.velocity = new Vector2(0, speed);
		}
		else if (Input.GetButton(ControlConst.DPAD_RIGHT)){
			Rigidbody2D.velocity = new Vector2(speed, 0);
		}
		else if (Input.GetButton(ControlConst.DPAD_DOWN)){
			Rigidbody2D.velocity = new Vector2(0, -speed);
		}
		else if (Input.GetButton(ControlConst.DPAD_LEFT)){
			Rigidbody2D.velocity = new Vector2(-speed, 0);
		}
		else{
			Rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
	
}
