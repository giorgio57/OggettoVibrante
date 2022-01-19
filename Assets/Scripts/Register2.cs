using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Register2 : MonoBehaviour
{
    public GameObject subjectID;
    public GameObject age;
    public GameObject gender;
    public GameObject notes;
    private string SubjectID;
    private string Age;
    private string Gender;
    private string Notes;
    private string form;

    public void RegisterButton()
    {
        bool SID = false;
        bool A = false;
        bool G = false;
        bool N = false;

        if (SubjectID != "")
        {
            if (!File.Exists(Application.streamingAssetsPath + "/Profiles/" + SubjectID + ".txt"))
            {
                SID = true;

            }
            else
            {
                Debug.LogWarning("Subject ID Taken");
            }
        }
        else
        {
            Debug.LogWarning("Subject ID field Empty");
            //chat.SendMessageToChat("Username field Empty");

        }

        if (Age != "")
        {
            A = true;
        }
        else
        {
            Debug.LogWarning("Age field Empty");
        }

        if (Gender != "")
        {
            G = true;
        }
        else
        {
            Debug.LogWarning("Gender field Empty");
        }

        if (Notes != "")
        {
            N = true;
        }
        else
        {
            Debug.LogWarning("Notes field Empty");
        }

        if (SID == true && A == true && G == true && N == true)
        {
            form = (SubjectID + Environment.NewLine + Age + Environment.NewLine + Gender + Environment.NewLine + Notes + Environment.NewLine);

            if (!File.Exists(Application.streamingAssetsPath + "/Profiles/" + SubjectID + ".txt"))
            {
                File.WriteAllText(Application.streamingAssetsPath + "/Profiles/" + SubjectID + ".txt", form);
            }

            PlayerPrefs.SetString("name", subjectID.GetComponent<InputField>().text);
            subjectID.GetComponent<InputField>().text = "";
            age.GetComponent<InputField>().text = "";
            gender.GetComponent<InputField>().text = "";
            notes.GetComponent<InputField>().text = "";
            
            print("Registration Complete");
            Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
        }
        else
        {
            File.Delete(Application.streamingAssetsPath + "/Profiles/" + SubjectID + ".txt");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (subjectID.GetComponent<InputField>().isFocused)
            {
                age.GetComponent<InputField>().Select();
            }
            if (age.GetComponent<InputField>().isFocused)
            {
                gender.GetComponent<InputField>().Select();
            }
            if (gender.GetComponent<InputField>().isFocused)
            {
                notes.GetComponent<InputField>().Select();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SubjectID != "" && Age != "" && Gender != "" && Notes != "")
            {
                RegisterButton();
            }
        }
        SubjectID = subjectID.GetComponent<InputField>().text;
        Age = age.GetComponent<InputField>().text;
        Gender = gender.GetComponent<InputField>().text;
        Notes = notes.GetComponent<InputField>().text;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene("InstructionMenu1");
    }
}

