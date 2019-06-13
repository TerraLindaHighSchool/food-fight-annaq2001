using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    private Rigidbody rb;
    private bool inAir = false;
    public float jumpScalar = 250;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && inAir)
        {
            rb.AddForce(Vector3.up * jumpScalar * 3);
            inAir = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpScalar);
        }*/

        if (inAir)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) {
                rb.AddForce(Vector3.up * jumpScalar * 5);
                inAir = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpScalar * 3);
                inAir = true;
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Space) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))) {
                rb.AddForce(Vector3.up * jumpScalar * 1.3f);
                inAir = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpScalar);
                inAir = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            inAir = false;
        }
    }
}
