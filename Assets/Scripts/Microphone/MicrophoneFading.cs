using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class MicrophoneFading : MonoBehaviour
{
    public float gravity = 10.0f;
    [Range(0, 1)] public float transp = 0.0f;
    public MicrophoneInput micVolume;
    [Range(0, 1)] public float moveSpeed;
    public SetTransparency SetTransp;
    public Sending Sending;


    void Start()
    {
        SetTransp.FadeT(0);
    }


    void FixedUpdate()
    {
        
        moveSpeed = micVolume.loudness * 0.015f;
        //Debug.Log(transp += moveSpeed);

        SetTransp.FadeT(transp += moveSpeed);

        if ((transp += moveSpeed) >= 0.7)
        {
            Sending.sendVibration();
        }

        if ((transp += moveSpeed) >= 0)
        {
            if ((transp += moveSpeed) != 0)
            {
                SetTransp.FadeT(transp -= gravity);
            }

        }

        if ((transp += moveSpeed) >= 1)
        {
            SetTransp.FadeT(1);
            SetTransp.FadeT(transp -= gravity);
        }

        if ((transp += moveSpeed) < 0)
        {
            SetTransp.FadeT(0);
        }


    }



}