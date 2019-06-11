using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchHeld : MonoBehaviour
{

    private Rigidbody rb;
    public float magnitude = 10f;
    public GameObject textObject;
    private Text text;
    private float delay = 0, textDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        text = textObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool holding = GetComponent<PickUpAndHold>().isHolding();
        if (holding)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                GameObject fruit = GetComponent<PickUpAndHold>().getFruit();
                Rigidbody fruitRb = fruit.GetComponent<Rigidbody>();
                fruitRb.AddForce(Vector3.forward * magnitude, ForceMode.Impulse);
                fruitRb.freezeRotation = false;
                fruitRb.useGravity = true;
                GetComponent<PickUpAndHold>().lauch();
                delay = Time.deltaTime * 10;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Return) && delay <= 0)
            {
                text.text = "you are not holding fruit";
                textDelay = Time.deltaTime * 60;
            }
        }
        if (delay > 0) delay -= Time.deltaTime;
        if (textDelay > 0) textDelay -= Time.deltaTime;
        else if (!holding) text.text = "";
    }
}
