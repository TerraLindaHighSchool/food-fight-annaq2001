using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision obj)
    {
        Debug.Log(obj.gameObject.name);
        if (obj.gameObject.name == "Plane")
        {
            Destroy(obj.gameObject);
        }
        else
            rb.AddForce(transform.up * 100, ForceMode.Force);
    }
}

