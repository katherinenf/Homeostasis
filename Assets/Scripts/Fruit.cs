using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fruit : MonoBehaviour
{
    public float timer;
    public float delayAmount;
    public Image fruitImage;
    public bool fruitCanGrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delayAmount)
        {
            fruitCanGrow = false;
        }
    }

    public void OnClick()
    {
        if (fruitCanGrow)
        {
            float fruitX = fruitImage.GetComponent<RectTransform>().localScale.x;
            float fruitY = fruitImage.GetComponent<RectTransform>().localScale.y;
            fruitImage.GetComponent<RectTransform>().localScale = new Vector3(fruitX + 0.1f, fruitY + 0.1f, 1);
        }
    }

}
