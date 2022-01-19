using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;

public class Timer : MonoBehaviour
{
    
    public Text timer;
    public float time;
    public float incrementIntensity;
    float msec;
    float sec;
    float min;

    public Shaker Shaker;
    public ColorLerper Color;
    public Image Background;
    public float duration = 6f;
    public MicrophoneFading MicrophoneFading;
    //public Sending Sending;

    public void StopWatchStart()
    {
        StartCoroutine("StopWatch");
        Shaker.Shake(duration);
        //Color.BufferColor();
    }
    public void StopWatchStop()
    {
        StopCoroutine("StopWatch");
        Shaker.Freeze();
        Color.BufferColor();
    }
    public void StopWatchReset()
    {
        time = 0;
        timer.text = "00:00:00";
        Color.SetStartColor();
        Shaker.Intensity = 0f;
    }

    IEnumerator StopWatch()
    {
        while (true)
        {
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);

            Color.ColorUpdate();

            Shaker.Intensity += incrementIntensity;
            /*if ((sec == 0) || (sec == 6) || (sec == 12) || (sec == 18) || (sec == 24) || (sec == 30) || (sec == 36) || (sec == 42) || (sec == 48) || (sec == 54))
            {
                Shaker.Shake(duration);
                Debug.Log("Shake");
            }*/

            /*if ((MicrophoneFading.transp += MicrophoneFading.moveSpeed) >= 0.7)
            {
                //StopCoroutine("StopWatch");
                Sending.sendVibration();
                //Background.gameObject.SetActive(true);
            }*/


            if ((MicrophoneFading.transp += MicrophoneFading.moveSpeed) >= 1)
            {
                //StopCoroutine("StopWatch");
                Shaker.Freeze();
                Color.SetStartColor();
                Shaker.Intensity = 0f;
                //Background.gameObject.SetActive(true);
            }


            if (sec == 0)
            {
                //StopCoroutine("StopWatch");
                Shaker.Freeze();
                Color.SetStartColor();
                Shaker.Intensity = 0f;
                //Background.gameObject.SetActive(true);
            }

            /*if (((sec % 6) == 0) && (sec != 0))
            {
                Shaker.Shake(duration);
            }*/

            if (sec != 0)
            {
                Shaker.Shake(duration);
            }



            yield return null;

           
        }
    }
}
