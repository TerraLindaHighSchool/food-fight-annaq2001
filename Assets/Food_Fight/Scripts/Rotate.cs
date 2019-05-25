using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private Rigidbody rb;
    public float rotateSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Comma))
        {
            if (Vector3.up == transform.up)
            {
                rb.transform.Rotate(0, rotateSpeed, 0, Space.Self);
            }
            else if (Vector3.up == -transform.up)
            {
                rb.transform.Rotate(0, -rotateSpeed, 0, Space.Self);
            }
            else if (Vector3.up == transform.forward)
            {
                rb.transform.Rotate(0, 0, rotateSpeed, Space.Self);
            }
            else if (Vector3.up == -transform.forward)
            {
                rb.transform.Rotate(0, 0, -rotateSpeed, Space.Self);
            }
            else if (Vector3.up == transform.right)
            {
                rb.transform.Rotate(rotateSpeed, 0, 0, Space.Self);
            }
            else if (Vector3.up == -transform.right)
            {
                rb.transform.Rotate(-rotateSpeed, 0, 0, Space.Self);
            }
        }
        else if (Input.GetKey(KeyCode.Period))
        {
            if (Vector3.up == transform.up)
            {
                rb.transform.Rotate(0, -rotateSpeed, 0, Space.Self);
            }
            else if (Vector3.up == -transform.up)
            {
                rb.transform.Rotate(0, rotateSpeed, 0, Space.Self);
            }
            else if (Vector3.up == transform.forward)
            {
                rb.transform.Rotate(0, 0, -rotateSpeed, Space.Self);
            }
            else if (Vector3.up == -transform.forward)
            {
                rb.transform.Rotate(0, 0, rotateSpeed, Space.Self);
            }
            else if (Vector3.up == transform.right)
            {
                rb.transform.Rotate(-rotateSpeed, 0, 0, Space.Self);
            }
            else if (Vector3.up == -transform.right)
            {
                rb.transform.Rotate(rotateSpeed, 0, 0, Space.Self);
            }
        }
    }
}
