using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Transform.position example.
//
// Animate a sphere around a circle and bounce up and down.

public class ExampleScript : MonoBehaviour
{
    private Vector3 spherePosition;
    private float xzPosition, yPosition;
    private float increaseXZPosition, increaseYPosition;

    void Awake()
    {
        // Three seconds per circular rotation.
        increaseXZPosition = (2.0f * Mathf.PI) / 3.0f;

        // Random speed up/down.
        increaseYPosition = (2.0f * Mathf.PI) / 1.3f;

        // Create a floor for the sphere to bounce on.
        GameObject quad;
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.rotation = Quaternion.Euler(90, 0, 0);
        quad.transform.localScale = new Vector3(8, 8, 1);

        // Sphere is 1 unit in size.  Drop floor by half this.
        quad.transform.position = new Vector3(0.0f, -0.5f, 0.0f);

        // Change the camera position and rotation.
        Camera.main.transform.position = new Vector3(2.5f, 7.5f, 0.8f);
        Camera.main.transform.rotation = Quaternion.Euler(65, -105, 0);
    }

    void Update()
    {
        // Move sphere around the circle.
        spherePosition = new Vector3(2.0f * Mathf.Sin(xzPosition), 4.0f * Mathf.Sin(yPosition), 2.0f * Mathf.Cos(xzPosition));
        transform.position = spherePosition;

        // Update the rotating position.
        xzPosition += increaseXZPosition * Time.deltaTime;
        if (xzPosition > 2.0f * Mathf.PI)
        {
            xzPosition = xzPosition - 2.0f * Mathf.PI;
        }

        // Update the up/down position.
        yPosition += increaseYPosition * Time.deltaTime;
        if (yPosition > Mathf.PI)
        {
            yPosition = yPosition - Mathf.PI;
        }
    }

    // Display the changing position of the sphere.
    void OnGUI()
    {
        GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
        fontSize.fontSize = 24;
        GUI.Label(new Rect(20, 20, 300, 50), "Position: " + spherePosition.ToString("F2"), fontSize);
    }
}