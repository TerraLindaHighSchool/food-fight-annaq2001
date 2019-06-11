using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSystem : MonoBehaviour
{
    //private Rigidbody rb;
    public GameObject player;
    public float rotateSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Comma))
        {
            //transform.RotateAround(Vector3.zero, Vector3.up, -rotateSpeed);
            transform.RotateAround(player.transform.position, Vector3.up, rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.Period))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -rotateSpeed);
        }
    }
}
