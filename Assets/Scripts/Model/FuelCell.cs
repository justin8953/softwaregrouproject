using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCell : MonoBehaviour
{
     public AudioSource source;

    void Start()
    {
        source = GameObject.Find("Rover").GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 60, 0) * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rover"))
        {
            KeepScore.Score += 1;
             source.Play();
            this.gameObject.SetActive(false);            
        }
    }
}
