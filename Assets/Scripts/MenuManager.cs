using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToHumanMode()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HumanGPScene");
    }
}
