using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class Controller : MonoBehaviour
{
    // Listen for player input
	public abstract void ReadInput(InputData data);

	protected Rigidbody rb;
	protected bool newInput;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}
}
