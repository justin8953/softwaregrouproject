using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardTracker : DeviceTracker
{
	public AxisKeys[] axisKeys;
	public KeyCode[] buttonKeys;

	void Reset() {
		im = GetComponent<InputManager>();
		axisKeys = new AxisKeys[im.axisCount];
		buttonKeys = new KeyCode[im.buttonCount];
	}

	public override void Refresh() {
		im = GetComponent<InputManager>();
		// 2 temp arrays fo buttons and axes
		KeyCode[] newButtons = new KeyCode[im.buttonCount];
		AxisKeys[] newAxes = new AxisKeys[im.axisCount];

		// Use method to do both?
		if(buttonKeys != null) {
			for (int i = 0; i < Mathf.Min(newButtons.Length, buttonKeys.Length); i++) {
				newButtons[i] = buttonKeys[i];
			}
		}
		buttonKeys = newButtons;

		if(axisKeys != null) {
			for (int i = 0; i < Mathf.Min(newAxes.Length, axisKeys.Length); i++) {
				newAxes[i] = axisKeys[i];
			}
		}
		axisKeys = newAxes;
	}

    // Update is called once per frame
    void Update()
    {
    	// Check for inputs
    	for(int i = 0; i < axisKeys.Length; i++) {
    		float val = 0f;
        	if(Input.GetKey(axisKeys[i].positive)) {
        		val += 1f; 
        		newData = true;
        	}
        	if(Input.GetKey(axisKeys[i].negative)) {
        		val -= 1f;
        		newData = true;
        	}
        	data.axes[i] = val;
        }

        // Check for inputs
        for(int i = 0; i < buttonKeys.Length; i++) {
        	if(Input.GetKey(buttonKeys[i])) {
        		data.buttons [i] = true;
        		newData = true;
        	}
        }

        // Fill out input data to send
        if(newData) {
        	im.PassInput(data);
        	newData = false;
        	data.Reset();
        }
    }
}

[System.Serializable]
public struct AxisKeys {
	public KeyCode positive;
	public KeyCode negative;
}