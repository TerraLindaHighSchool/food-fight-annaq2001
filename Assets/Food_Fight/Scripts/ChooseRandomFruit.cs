using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit
{
    public string Name { get; }
    public int Num { get; set; }
    public float Size { get; }

    public Fruit(string p_name, int p_num, float p_size)
    {
        Name = p_name;
        Num = p_num;
        Size = p_size;
    }

    public void decrement()
    {
        Num--;
    }
}

public class ChooseRandomFruit : MonoBehaviour
{

    public int numApple = 5, numAvocado = 5, numBanana = 5, numBasil = 5, numBread = 5, numBroccoli = 5,
        numCarrot = 5, numCucumber = 5, numLeek = 5, numLemon = 5, numMushroom = 5, numOnion = 5, numPear = 5, 
        numPepperoni = 5, numStrawberry = 5, numTomato = 5;
    private List<Fruit> fruits;
    //public GameObject apple;
    public float scale = 2;
    private int totalFruit = 0;
    public GameObject textObject;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        fruits = new List<Fruit>();
        if (numApple > 0) fruits.Add(new Fruit("Apple", numApple, 5));
        if (numAvocado > 0) fruits.Add(new Fruit("Avocado", numAvocado, 5));
        if (numBanana > 0) fruits.Add(new Fruit("Banana", numBanana, 5));
        if (numBasil > 0) fruits.Add(new Fruit("Basil", numBasil, 2.5f));
        if (numBread > 0) fruits.Add(new Fruit("Bread", numBread, 3));
        if (numBroccoli > 0) fruits.Add(new Fruit("Broccoli", numBroccoli, 3));
        if (numCarrot > 0) fruits.Add(new Fruit("Carrot", numCarrot, 3));
        if (numCucumber > 0) fruits.Add(new Fruit("Cucumber", numCucumber, 2.5f));
        if (numLeek > 0) fruits.Add(new Fruit("Leek", numLeek, 0.3f));
        if (numLemon > 0) fruits.Add(new Fruit("Lemon", numLemon, 5));
        if (numMushroom > 0) fruits.Add(new Fruit("Mushroom", numMushroom, 5));
        if (numOnion > 0) fruits.Add(new Fruit("Onion", numOnion, 5));
        if (numPear > 0) fruits.Add(new Fruit("Pear", numPear, 5));
        if (numPepperoni > 0) fruits.Add(new Fruit("Pepperoni", numPepperoni, 3.5f));
        if (numStrawberry > 0) fruits.Add(new Fruit("Strawberry", numStrawberry, 2.5f));
        if (numTomato > 0) fruits.Add(new Fruit("Tomato", numTomato, 5));
        fruits.ForEach(delegate (Fruit fruit)
        {
            totalFruit += fruit.Num;
        });

        text = textObject.GetComponent<Text>();
        text.text = totalFruit + " Fruits";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int rand = Random.Range(0, fruits.Count);
            GameObject fruit;
            //fruit = Instantiate(GameObject.Find("/Fruit Block/" + fruits[0].name), new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
            fruit = Instantiate(GameObject.Find("/Floor/Fruit Block/" + fruits[rand].Name), new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
            fruit.transform.localScale = new Vector3(fruits[rand].Size * scale, fruits[rand].Size * scale, fruits[rand].Size * scale);
            Rigidbody fruitRb = fruit.AddComponent<Rigidbody>();

            fruits[rand].decrement();
            totalFruit--;
            if (fruits[rand].Num <= 0) fruits.RemoveAt(rand);

            text.text = totalFruit + " Fruits";
        }
    }
}
