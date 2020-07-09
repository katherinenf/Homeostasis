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
    public Image Open;
    public Image Closed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MeterControl();
    }

    public void OnClick()
    {
        if (stomataOpen)
        {
            stomataOpen = false;
            Open.enabled = false;
            Closed.enabled = true;
        }
        else
        {
            stomataOpen = true;
            Closed.enabled = false;
            Open.enabled = true;
        }
    }

    public void MeterControl()
    {
        RectTransform H2OBar = H2OMeter.GetComponent<RectTransform>();
        RectTransform CO2Bar = CO2Meter.GetComponent<RectTransform>();
        if (stomataOpen)
        {
            if (H2OBar.rect.height <= 100)
            {
                H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height + (10 * Time.deltaTime));
            }
            //H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height + 10);
            if (CO2Bar.rect.height > 0)
            {
                CO2Bar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, CO2Bar.rect.height - (10 * Time.deltaTime));
            }
        }

        else
        {
            if (H2OBar.rect.height > 0)
            {
                H2OBar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, H2OBar.rect.height - (10 * Time.deltaTime));
            }
            if (CO2Bar.rect.height <= 100)
            {
                CO2Bar.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, CO2Bar.rect.height + (10 * Time.deltaTime));
            }
        }
    }
}

