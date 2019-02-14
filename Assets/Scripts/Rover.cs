using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour
{
    public Rigidbody rb;
    private bool moving = true;
    private Vector3 initialPos; 
    private float distance;
    private float rotation;
    private Quaternion initialAngle;
    private bool begin = true;
    public float moveVelocity;

    public AudioClip fuelcellsound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moving) {
        	forward();
        	//turn_left();
        }
    }

    // void turn_left()
    // {
	   // 	if(begin) {
	   // 		initialAngle = rb.rotation;
	   // 		Debug.Log(initialAngle);
    // 		begin = false;
    // 	}
    // 	rotation = Quaternion.Angle(initialAngle, rb.rotation);
    // 	Debug.Log(rotation);
    // 	if(rotation <= 90f) {
    // 		rb.rotation += 1f;
    // 	} else {
    // 		begin = true;
    // 		moving = false;
    // 		rotation = 0;
    // 	}	
    // }

    void forward()
    {
	   	if(begin) {
	   		initialPos = rb.position;
    		begin = false;
    	}
    	distance = Vector3.Distance(initialPos, rb.position);
    	if(distance < 1f) {
    		rb.velocity += Vector3.right * moveVelocity * Time.deltaTime;
    		Debug.Log(distance);
    	} else {
    		begin = true;
    		moving = false;
    		distance = 0;
    		rb.velocity = Vector3.zero;
    	}	
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.Play();
            other.gameObject.SetActive(false);
        }
    }

}
