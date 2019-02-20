using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rover : MonoBehaviour
{
    public Rigidbody rb;
    public bool moving;
    public Vector3 initialPos; 
    public float distance;
    public float rotation;
    public Quaternion initialAngle;
    public bool begin = true;
    public float speed;
    public bool commandFinished = false;

    public void Start()
    {
        moving = false;
    }

    public void forward()
    {
	   	if(begin) {
	   		initialPos = rb.position;
    		begin = false;
    	}
        distance = Vector3.Distance(initialPos, rb.position);
    	if(distance + (speed * Time.deltaTime) < 1f) {
            rb.transform.Translate(Vector3.forward * speed * Time.deltaTime);
     	} else {
            rb.transform.Translate(new Vector3(0, 0, 1f-distance));
            commandFinished = true;
            begin = true;
    	}
    }

    public void left()
    {
        if(begin) {
	   		initialAngle = rb.rotation;
            begin = false;
    	}
        rotation = Quaternion.Angle(initialAngle, rb.rotation);
    	if(rotation < 90f) {
    	    rb.transform.Rotate(new Vector3(0, -200, 0) * Time.deltaTime);
    	} else {
            rb.transform.Rotate(new Vector3(0, -90f+rotation, 0));
            commandFinished = true;
            begin = true;
    	}	
    }

    public void right()
    {
        Vector3 rotSpeed = new Vector3(0f, 200f, 0f);

        if(begin) {
	   		initialAngle = rb.rotation;
            begin = false;
    	}
        rotation = Quaternion.Angle(initialAngle, rb.rotation);
    	if(rotation < 90f) {
            rb.transform.Rotate(rotSpeed * Time.deltaTime);
    	} else {
            rb.transform.Rotate(new Vector3(0, 90f-rotation, 0));
            commandFinished = true;
    		begin = true;
    	}	
    }
}
