using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Leaf : MonoBehaviour
{
    public bool stomataOpen;
    public bool isItHot;
    public Image CO2Meter;
    public Image H2OMeter;
    public Image open;
    public Image closed;
    public Image leaf;
    public bool photosynthesisHappening;
    bool stopDaLeaf = false;
    public bool youDead = false;
    public Text EventText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RectTransform H2OBar = H2OMeter.GetComponent<RectTransform>();
        RectTransform CO2Bar = CO2Meter.GetComponent<RectTransform>();
        MeterControl();
        if (open.enabled == true)
        {
            leaf = open;
        }
        else
        {
            leaf = closed;
        }
        if (H2OBar.rect.height <= 0 || CO2Bar.rect.height <= 0)
        {
            youDead = true;
            leaf.color = Color.gray;
            EventText.text = "your leaf has died :(";
            this.enabled = false;
            stopDaLeaf = true;  
        }
        if (H2OBar.rect.height >= 50 && CO2Bar.rect.height >= 50)
        {
            photosynthesisHappening = true;
            leaf.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1.5f);
            this.enabled = false;
            stopDaLeaf = true;
            EventText.text = "Photosynthesis!";
        }

    }

    public void OnClick()
    {
        if (!stopDaLeaf)
        {
            if (stomataOpen)
            {
                stomataOpen = false;
                open.enabled = false;
                closed.enabled = true;
            }
            else
            {
                stomataOpen = true;
                closed.enabled = false;
                open.enabled = true;
            }
        }
    }

    public void MeterControl()
    {
        RectTransform H2OBar = H2OMeter.GetComponent<RectTransform>();
        RectTransform CO2Bar = CO2Meter.GetComponent<RectTransform>();
        if (stomataOpen)
        {
            if (H2OBar.rect.height >= 0)
            {
                H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height - (5 * Time.deltaTime));
            }
            if (CO2Bar.rect.height <= 100)
            {
                CO2Bar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, CO2Bar.rect.height + (10 * Time.deltaTime));
            }
        }

        else
        {
            if (H2OBar.rect.height <= 100)
            {
                H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height + (10 * Time.deltaTime));
            }
            if (CO2Bar.rect.height >= 0)
            {
                CO2Bar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, CO2Bar.rect.height - (5 * Time.deltaTime));
            }
        }
    }
}

