using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NextButtonCommand : MonoBehaviour
{
    public Button NextButton;

    public void Start()
    {
        NextButton.gameObject.SetActive(false);
    }

    public void Update()
    {
        
        Invoke("NextAppear", 180.0f);
    }

    private void NextAppear()
    {
        if (NextButton.gameObject.activeSelf == false)
        {
            NextButton.gameObject.SetActive(true);
        }
    }
}