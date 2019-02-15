using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

	Vector3 walkVelocity;
	public float walkSpeed;

	public override void ReadInput(InputData data)
	{

		walkVelocity = Vector3.zero;

		if(data.axes[0] != 0f) {
			walkVelocity += Vector3.forward * data.axes[0] * walkSpeed;
		}

		if(data.axes[1] != 0f) {
			walkVelocity += Vector3.right * data.axes[1] * walkSpeed;
		}

		newInput = true;

	}

	void LateUpdate() {
		if(!newInput) {
			walkVelocity = Vector3.zero;
		}
		rb.velocity = new Vector3(walkVelocity.x, rb.velocity.y, walkVelocity.z);
		newInput = false;
	}
}
