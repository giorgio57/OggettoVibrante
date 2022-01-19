using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTester : MonoBehaviour
{
    public Shaker Shaker;
    public int duration = 6;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Shaker.Shake(duration);
        }
    }
}
