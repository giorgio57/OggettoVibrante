using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class Sending : MonoBehaviour
{
    public static SerialPort sp = new SerialPort("COM3", 9600);
    public string message;
    public float timePassed = 960.0f;
    // Start is called before the first frame update
    void Start()
    {
        OpenConnection();

    }

    // Update is called once per frame
    void Update()
    { 
        message = sp.ReadLine();
        Debug.Log(message);
        sp.BaseStream.Flush();
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                Debug.Log("Closing port, already open");
            }
            else
            {
                sp.Open();
                sp.WriteTimeout = 16;
                sp.DtrEnable = true;
                sp.RtsEnable = true;
                Debug.Log("Port Opened");
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                Debug.Log("Port already open");
            }
            else
            {
                Debug.Log("Port == null");
            }
        }
    }

    public void OnApplicationQuit()
    {
        sp.Close();
    }

    public static void sendVibration()
    {
        sp.Write("AA\n");
        sp.BaseStream.Flush();
    }
}
