using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButtonHandler : MonoBehaviour
{
    public KeyCode Key;

    private Button Button;

    void Awake()
    {
        Button = GetComponent<Button>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(Key))
        {
            Button.onClick.Invoke();
        }
        
    }
}
