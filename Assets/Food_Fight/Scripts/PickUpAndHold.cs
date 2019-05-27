using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndHold : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject fruit;
    private bool holding = false;
    public Vector3 offset = new Vector3(0f, 1f, 0f);
    public float[] range = { 3f, 5f };
    private float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delay > 0) delay -= Time.deltaTime;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && holding)
        {
            holding = false;
            delay = 1.5f;
            fruit.GetComponent<Rigidbody>().AddForce(Random.Range(range[0], range[1]), Random.Range(range[0], range[1]), Random.Range(range[0], range[1]));
        }

        if (holding)
        {
            //fruit.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            fruit.transform.position = transform.position + offset;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!holding && delay <= 0)
        {
            if (collision.gameObject.tag == "Fruit")
            {
                holding = true;
                fruit = collision.gameObject;
                fruit.GetComponent<Rigidbody>().freezeRotation = true;

                //fruit.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                fruit.transform.position = transform.position + offset;
            }
        }
    }
}
