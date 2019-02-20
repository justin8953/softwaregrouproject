using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoverController : MonoBehaviour
{
    public Rigidbody rb;
    private bool moving;
    private Vector3 initialPos; 
    private float distance;
    private float rotation;
    private Quaternion initialAngle;
    private bool begin = true;
    public float speed;
    private float deltaAngle = 0f;

    // Create a class to store pc count
    private int[] commands = new int[10];
    private int pc = 0;
    public Text program;

    private Renderer Object_render;
    public Button Forward, Left, Right, Go;
    bool FD_isValid, LT_isValid, RT_isValid, GO_isValid;
    public AudioClip fuelcellsound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moving = false;
        FD_isValid = LT_isValid = RT_isValid = GO_isValid = false;
        Forward = GameObject.Find("Forward").GetComponent<Button>();
        Left = GameObject.Find("Turn Left").GetComponent<Button>();
        Right = GameObject.Find("Turn Right").GetComponent<Button>();
        Go = GameObject.Find("Go").GetComponent<Button>();

        source = GetComponent<AudioSource>();
        program.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        setCommand();
        Forward.onClick.AddListener(FDOnClick);
        Left.onClick.AddListener(LTOnClick);
        Right.onClick.AddListener(RTOnClick);
        Go.onClick.AddListener(GOOnClick);
        if(moving) {
            runProgram();
        }
    }

    private void setCommand()
    {
        if(FD_isValid) {
            program.text += "forward();\n";
            commands[pc] = 1;
            pc++;
            FD_isValid = false;
        } else if(LT_isValid) {
            program.text += "turn_left();\n";
            commands[pc] = 2;
            pc++;
            LT_isValid = false;
        } else if(RT_isValid) {
            program.text += "turn_right();\n";
            commands[pc] = 3;
            pc++;
            RT_isValid = false;
        } else if(GO_isValid) {
            pc = 0;
            moving = true;
            GO_isValid = false;
        }
    }

    void runProgram() 
    {
        switch (commands[pc]) {
        case 0:
            reset();
            break;
        case 1:
            forward();
            break;
        case 2:
            turn_left();
            break;
        case 3:
            turn_right();
            break;
        default:
            break;
      }
    }

    void reset()
    {
        pc = 0;
        moving = false;
        program.text = "";
        for(int i=0; i < commands.Length; i++) {
            commands[i] = 0;
        }
    }

    void forward()
    {
	   	if(begin) {
	   		initialPos = rb.position;
    		begin = false;
    	}
        distance = Vector3.Distance(initialPos, rb.position);
    	if(distance + (speed * Time.deltaTime) < 1f) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
     	} else {
            transform.Translate(new Vector3(0, 0, 1f-distance));
    		begin = true;
            rb.velocity = Vector3.zero;
            pc++;
    	}
    }

    void turn_left()
    {
        float deltaAngle = 0f;

        if(begin) {
	   		initialAngle = rb.rotation;
    	}
        rotation = Quaternion.Angle(initialAngle, rb.rotation);
    	if(rotation + deltaAngle < 90f) {
    	    transform.Rotate(new Vector3(0, -200, 0) * Time.deltaTime);
            if(begin) {
                deltaAngle = Mathf.Abs(Quaternion.Angle(initialAngle, rb.rotation));
                begin = false;
            }
    	} else {
            transform.Rotate(new Vector3(0, -90f+rotation, 0));
    		begin = true;
    		pc++;
    	}	
    }

    void turn_right()
    {
        Vector3 rotSpeed = new Vector3(0f, 200f, 0f);

        if(begin) {
	   		initialAngle = rb.rotation;
    	}
        rotation = Quaternion.Angle(initialAngle, rb.rotation);
    	if(rotation + deltaAngle< 90f) {
            transform.Rotate(rotSpeed * Time.deltaTime);
            if(begin) {
                deltaAngle = Mathf.Abs(Quaternion.Angle(initialAngle, rb.rotation));
                Debug.Log(deltaAngle);
                begin = false;
            }
    	} else {
            transform.Rotate(new Vector3(0, 90f-rotation, 0));
    		begin = true;
    		pc++;
    	}	
    }

    void FDOnClick()
    {
        FD_isValid = true;
    }
    void LTOnClick()
    {
        LT_isValid = true;
    }
    void RTOnClick()
    {
        RT_isValid = true;
    }
    void GOOnClick()
    {
        GO_isValid = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);            
            float vol = Random.Range(volLowRange, volHighRange);
            source.Play();
        }
    }

}
