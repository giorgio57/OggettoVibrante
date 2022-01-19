using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundCommand : MonoBehaviour
{
    public Image Background;

    public void PressTryAgain()
    {
        Background.gameObject.SetActive(false);
        
    }
}
