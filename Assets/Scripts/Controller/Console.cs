using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Console : Rover, IDropHandler
{
    public Button runButton;
    private int[] commands = new int[10];
    private int pc = 0;
    public Text program;

    void Start()
    {
        runButton = GameObject.Find("Run").GetComponent<Button>();
    }

    void Update()
    {
        runButton.onClick.AddListener(RunOnClick);
        if(moving) {
            if(commandFinished) {
                commandFinished = false;
                pc++;
            }
            runProgram();
        }
    }

    void RunOnClick()
    {
        if(!moving) moving = true;  
        pc = 0;  
    }

    void runProgram()
    {
        switch (commands[pc]) {
            case 0:
                moving = false;
                break;
            case 1:
                forward();
                break;
            case 2:
                left();
                break;
            case 3:
                right();
                break;
            default:
                pc = 0;
                moving = false;
                break;
        }
    }

    public void OnDrop(PointerEventData eventData) {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if(d != null) {
            if(eventData.pointerDrag.name == "forward") {
                program.text += "forward();\n";
                commands[pc] = 1;
                pc++;
            }
            if(eventData.pointerDrag.name == "left") {
                program.text += "turn_left();\n";
                commands[pc] = 2;
                pc++;
            }
            if(eventData.pointerDrag.name == "right") {
                program.text += "turn_right();\n";
                commands[pc] = 3;
                pc++;
            }           
        }
    }
}