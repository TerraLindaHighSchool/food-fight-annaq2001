using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        newPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Fruit")
        newPosition();
    }

    private void newPosition()
    {
        Vector3 position;
        float rotateY;
        switch (Random.Range(0, 4))
        {
            case 0:
                position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(0.25f, 1.75f), -4.892f);
                //position = new Vector3(Random.Range(-23f, 23f), Random.Range(1f, 8f), -24.4f);
                rotateY = 90f;
                break;
            case 1:
                position = new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(0.25f, 1.75f), 4.892f);
                //position = new Vector3(Random.Range(-23f, 23f), Random.Range(1f, 8f), 24.4f);
                rotateY = 90f;
                break;
            case 2:
                position = new Vector3(-4.892f, Random.Range(0.25f, 1.75f), Random.Range(-4.5f, 4.5f));
                //position = new Vector3(-24.4f, Random.Range(1f, 8f), Random.Range(-23f, 23f));
                rotateY = 0f;
                break;
            case 3:
                position = new Vector3(4.892f, Random.Range(0.25f, 1.75f), Random.Range(-4.5f, 4.5f));
                //position = new Vector3(24.4f, Random.Range(1f, 8f), Random.Range(-23f, 23f));
                rotateY = 0f;
                break;
            default:
                position = new Vector3(0, 0, 0);
                rotateY = 90f;
                break;
        }
        transform.localPosition = position;
        transform.Rotate(0, rotateY - transform.rotation.y, 0);
        //transform.RotateAround(transform.position, Vector3.up, rotateY - transform.rotation.y);
    }
}
