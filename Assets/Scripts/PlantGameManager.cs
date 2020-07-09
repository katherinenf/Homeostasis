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



    // Start is called before the first frame update
    void Start()
    {
        photosynthesisText.text = "No Photosynthesis. Are you missing water, sunlight, or CO2?";
        responseText.text = "Stomata Open";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {
            timer = 0f;
            if (isItDay)
            {
                NightStart();
            }
            else
            {
                DayStart();
            }
        }

        if (isItDay)
        {
            //DayUpdate();
        }

/*        if (photosynthesis)
        {
            health += Time.deltaTime * healthChangePerSecond;
        }
        if(isItDay && !photosynthesis)
        {
            health -= Time.deltaTime * healthChangePerSecond;
        }*/

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

    /*      public void DayUpdate()
        {
            if (CO2Slider.value != 0 && H2OSlider.value != 0)
            {
                photosynthesisText.text = "Photosynthesis occuring! Using up that H2O and CO2 to make food!";
                photosynthesisText.color = Color.yellow;
                CO2Slider.value -= photosynthesisRate * Time.deltaTime;
                H2OSlider.value -= photosynthesisRate * Time.deltaTime;
            }
            else
            {
                photosynthesisText.text = "No Photosynthesis. Are you missing water, sunlight, or CO2?";
                photosynthesisText.color = Color.white;
            }
        }*/

    //change response to match stimulus
    //change response text to display condition of stomata
    //alter CO2 and H2O sliders to reflect whether CO2 and H2O are being gained or lost
    public void StomataOpen()
    {
        responseText.text = "Stomata Open";
        RectTransform H2OBar = H2OMeter.GetComponent<RectTransform>();
        if (H2OBar.rect.height > 0)
        {
            H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height - 10);
        }
        RectTransform CO2Bar = CO2Meter.GetComponent<RectTransform>();
        if (CO2Bar.rect.height <= 100)
        {
            CO2Bar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, CO2Bar.rect.height + 10);
        }
    }

    public void StomataClosed()
    {
        responseText.text = "Stomata Closed";
        RectTransform H2OBar = H2OMeter.GetComponent<RectTransform>();
        if(H2OBar.rect.height <= 100)
        {
            if (!isItDay)
            {
                H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height + 20);
            }
            H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height + 10);
        }
        RectTransform CO2Bar = CO2Meter.GetComponent<RectTransform>();
        if (CO2Bar.rect.height > 0)
        {
            CO2Bar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, CO2Bar.rect.height - 10);
        }
    }

}
