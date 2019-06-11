using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpAndHold : MonoBehaviour
{

    //private Rigidbody rb;
    private GameObject fruit;
    private bool holding = false;
    public Vector3 offset = new Vector3(0f, 1f, 0f);
    //public float[] range = { 3f, 5f };
    public float range = 5f;
    public float holdDelay = 2f;
    private float delay = 0;
    public GameObject textObject;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        text = textObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (fruit != null)
        {
            if (delay > 0) delay -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Escape) && holding)
            {
                fruit.GetComponent<Rigidbody>().freezeRotation = false;
                holding = false;
                delay = holdDelay;
                //fruit.GetComponent<Rigidbody>().AddForce(Random.Range(range[0], range[1]), Random.Range(range[0], range[1]), Random.Range(range[0], range[1]));
                fruit.GetComponent<Rigidbody>().AddForce(Random.Range(-range, range), range, Random.Range(-range, range));
                text.text = "";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                //fruit.GetComponent<Rigidbody>().freezeRotation = false;
                //delay = holdDelay;
                //text.text = "";
                //holding = false;
            }

            if (holding)
            {
                //fruit.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                fruit.transform.position = transform.position + offset;
            }
        }*/
        /*else
        {
            holding = false;
            text.text = "";
        }*/
    }

    void FixedUpdate()
    {
        if (fruit != null)
        {
            if (delay >= 0) delay -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Escape) && holding)
            {
                fruit.GetComponent<Rigidbody>().freezeRotation = false;
                fruit.GetComponent<Rigidbody>().useGravity = true;
                holding = false;
                delay = holdDelay;
                //fruit.GetComponent<Rigidbody>().AddForce(Random.Range(range[0], range[1]), Random.Range(range[0], range[1]), Random.Range(range[0], range[1]));
                fruit.GetComponent<Rigidbody>().AddForce(Random.Range(-range, range), range, Random.Range(-range, range));
                text.text = "";
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                //fruit.GetComponent<Rigidbody>().freezeRotation = false;
                //delay = holdDelay;
                //text.text = "";
                holding = false;
            }

            if (holding)
            {
                //fruit.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                fruit.transform.position = transform.position + offset;
            }
        }
        /*else
        {
            holding = false;
            text.text = "";
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!holding && delay <= 0)
        {
            if (collision.gameObject.tag == "Fruit")
            {
                holding = true;
                fruit = collision.gameObject;
                //fruit.transform.Rotate(-fruit.transform.rotation.x, -fruit.transform.rotation.y, -fruit.transform.rotation.y);
                fruit.GetComponent<Rigidbody>().freezeRotation = true;
                fruit.GetComponent<Rigidbody>().useGravity = false;

                //fruit.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                fruit.transform.position = transform.position + offset;

                string name = fruit.name.Substring(0, fruit.name.IndexOf("("));
                //text.text = "holding a " + name;
                text.text = name;
            }
        }
    }

    public bool isHolding()
    {
        return holding;
    }

    public void setHolding(bool h)
    {
        holding = h;
    }

    public GameObject getFruit()
    {
        return fruit;
    }

    public void lauch()
    {
        holding = false;
        fruit.GetComponent<Rigidbody>().freezeRotation = false;
        fruit.GetComponent<Rigidbody>().useGravity = true;
        delay = holdDelay;
        text.text = "";
    }
}
