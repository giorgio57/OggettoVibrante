using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{

    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    public Color bufferColor;
    public Color resetColor;
    public bool repeatable = false;
    float startTime;

    // Use this for initialization
    public void Start()
    {
        resetColor = startColor;
        startTime = Time.time;
    }

    
    public void ColorUpdate()
    {
        if (!repeatable)
        {
            float t = (Time.time - startTime) * speed;
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            float t = (Mathf.Sin(Time.time - startTime) * speed);
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }
    }

    public void SetStartColor()
    {
        GetComponent<Renderer>().material.color = resetColor;
        startColor = resetColor;
        startTime = Time.time;
    }

    public void BufferColor()
    {
        bufferColor = GetComponent<Renderer>().material.color;
        startColor = bufferColor;
        startTime = Time.time;

    }
}