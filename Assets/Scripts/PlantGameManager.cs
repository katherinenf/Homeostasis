using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlantGameManager : MonoBehaviour
{
    public GameObject background;
    public float health;
    public bool photosynthesis;
    public float timer;
    public float delayAmount;
    public bool isItDay;
    public Text responseText;
    public Text photosynthesisText;
    public Image CO2Meter;
    public Image H2OMeter;
    public Image PhotosynthesisMeter;
    public List<Leaf> leaves;
    public bool timeForFruit = false;
    public Fruit fruitPrefab;
    public bool thereIsAFruit = false;
    public Canvas mainCanvas;



    // Start is called before the first frame update
    void Start()
    {
        photosynthesisText.text = "No Photosynthesis. Are you missing water, sunlight, or CO2?";
        responseText.text = "Stomata Open";
    }

    // Update is called once per frame
    void Update()
    {
     foreach(Leaf l in leaves)
        {
            if(l.photosynthesisHappening == true)
            {
                timeForFruit = true;
            }
            else
            {
                timeForFruit = false;
                return;
            }
        }
        if (timeForFruit && !thereIsAFruit)
        {
            Fruit newFruit = Instantiate(fruitPrefab);
            newFruit.transform.position = new Vector2(0, 0);
            newFruit.transform.SetParent(mainCanvas.transform, false);
            thereIsAFruit = true;
        }

    }

    //change from day to night, change background color, update photosynthesis text
    public void NightStart()
    {
        background.GetComponent<SpriteRenderer>().color = new Color32(175, 175, 175, 255);

        isItDay = false;
        photosynthesisText.text = "No sunlight meants no photosynthesis!";
        photosynthesisText.color = Color.white;
    }

     public void DayStart()
    {
        background.GetComponent<SpriteRenderer>().color = Color.white;
        isItDay = true;
    }

    public void ToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

}
