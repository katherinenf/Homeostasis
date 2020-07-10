using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Fruit : MonoBehaviour
{
    public float timer;
    public float delayAmount;
    public Image fruitImage;

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
            //fruit can grow bigger
        }
    }

    public void OnClick()
    {
        Vector2 fruitScale = fruitImage.GetComponent<RectTransform>().localScale;
        fruitScale = new Vector2(fruitScale.x + 0.5f, fruitScale.y + 0.5f);
    }

}
