using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsOnCollide : MonoBehaviour
{

    public GameObject fruitTextObject, scoreTextObject;
    private Text fruitText, scoreText;
    private int points = 0;
    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        fruitText = fruitTextObject.GetComponent<Text>();
        scoreText = scoreTextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Fruit")
        {
            points += Mathf.FloorToInt(transform.position.y);
            Destroy(collider.gameObject);
            fruitText.text = "";
            scoreText.text = "Score: " + points;
            GameObject.Find("Player").GetComponent<PickUpAndHold>().setHolding(false);
            Debug.Log("points:" + points);
        }
    }
}
