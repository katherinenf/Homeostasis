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
    public int healthChangePerSecond;
    public Text responseText;
    public Slider CO2Slider;
    public Slider H2OSlider;
    public Text photosynthesisText;
    public float photosynthesisRate;
    public bool stomataOpen;
    public Text healthText;



    // Start is called before the first frame update
    void Start()
    {
        photosynthesisText.text = "No Photosynthesis. Are you missing water, sunlight, or CO2?";
        responseText.text = "Stomata Open. You're letting in CO2 but losing H2O!";
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "health: " + ((int)health).ToString();
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

        if (stomataOpen)
        {
            if (H2OSlider.value != 0)
            {
                H2OSlider.value -= Time.deltaTime;
            }
            CO2Slider.value += Time.deltaTime;
        }
        else
        {
/*            if (CO2Slider.value != 0)
            {
                CO2Slider.value -= Time.deltaTime;
            }*/
            H2OSlider.value += 2 * Time.deltaTime;
        }
        if (photosynthesis)
        {
            health += Time.deltaTime * healthChangePerSecond;
        }
        if(isItDay && !photosynthesis)
        {
            health -= Time.deltaTime * healthChangePerSecond;
        }

    }

    //change from day to night, change background color, update photosynthesis text
    public void NightStart()
    {
        background.GetComponent<SpriteRenderer>().color = new Color32(73, 73, 73, 255);
        isItDay = false;
        photosynthesisText.text = "No Photosynthesis. Are you missing water, sunlight, or CO2?";
        photosynthesisText.color = Color.white;
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
    }

    //change response to match stimulus
    //change response text to display condition of stomata
    //alter CO2 and H2O sliders to reflect whether CO2 and H2O are being gained or lost
    public void StomataOpen()
    {
        responseText.text = "Stomata Open. You're letting in CO2 but losing H2O!";
        stomataOpen = true;
    }

    public void StomataClosed()
    {
        responseText.text = "Stomata Closed You're building up H2O but not getting any CO2!";
        stomataOpen = false;
    }

}
