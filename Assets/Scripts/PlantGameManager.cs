using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlantGameManager : MonoBehaviour
{
    public GameObject background;
    public string stimulus;
    public string response;
    public float health;
    public bool photosynthesis;
    public float timer;
    public float delayAmount;
    public bool isItDay;
    public int healthLossPerSecond;
    public Text responseText;
    public Slider CO2Slider;
    public Slider H2OSlider;
    public Text photosynthesisText;
    public float photosynthesisRate;



    // Start is called before the first frame update
    void Start()
    {
        photosynthesisText.text = "No Photosynthesis";
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
            DayUpdate();
        }
    }

    //change from day to night, change background color, update photosynthesis text
    public void NightStart()
    {
        background.GetComponent<SpriteRenderer>().color = new Color32(73, 73, 73, 255);
        isItDay = false;
        photosynthesisText.text = "No Photosynthesis";      
    }

     public void DayStart()
    {
        background.GetComponent<SpriteRenderer>().color = Color.white;
        isItDay = true;
    }

      public void DayUpdate()
    {
        if (CO2Slider.value != 0 && H2OSlider.value != 0)
        {
            photosynthesisText.text = "Photosynthesis occuring!";
            CO2Slider.value -= photosynthesisRate * Time.deltaTime;
            H2OSlider.value -= photosynthesisRate * Time.deltaTime;
        }
    }

    //change response to match stimulus
    //change response text to display condition of stomata
    //alter CO2 and H2O sliders to reflect whether CO2 and H2O are being gained or lost
    public void StomataOpen()
    {
        responseText.text = "Stomata Open";
        if(H2OSlider.value != 0)
        {
            H2OSlider.value = H2OSlider.value - 2f;
        }
        CO2Slider.value = CO2Slider.value + 2f;
    }

    public void StomataClosed()
    {
        responseText.text = "Stomata Closed";
        if(CO2Slider.value != 0)
        {
            CO2Slider.value = CO2Slider.value - 1f;
        }
        H2OSlider.value = H2OSlider.value + 2f;
    }

}
