using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiding : MonoBehaviour {
    public bool inCloset; 
	// Use this for initialization
	void Start () {
        inCloset = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("closet")) {
            Debug.Log("hiding in a closet");
            inCloset = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("closet"))
        {
            Debug.Log("out of the closet");
            inCloset = false;
        }
    }
}
