using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text.RegularExpressions;


public class ToTextFile : MonoBehaviour
{
    public static string eventstring = "";
    // Start is called before the first frame update
    void Start()
    {
        //create the folder
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Event_Logs/");

        CreateTexFile();
    }

    
    public void CreateTexFile()
    {
        // create the text file at the already created directory in the start function
        string txtDocumentName = Application.streamingAssetsPath + "/Event_Logs/" + "Chat - " + PlayerPrefs.GetString("name") + ".txt";

        // check if the text exists. if it doesnt exist create one
        if (!File.Exists(txtDocumentName))
        {
            File.WriteAllText(txtDocumentName, "EVENT LOG - " + PlayerPrefs.GetString("name") + Environment.NewLine + Environment.NewLine);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        string txtDocumentName = Application.streamingAssetsPath + "/Event_Logs/" + "Chat - " + PlayerPrefs.GetString("name") + ".txt";

        if (collision.transform.name == "FPSController")
        {
            eventstring = ("Hit the " + gameObject.ToString());
            string content = ("[" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff") + "] " + CollisionCount.eventstring + Environment.NewLine);
            File.AppendAllText(txtDocumentName, content);

        }
    }
}
