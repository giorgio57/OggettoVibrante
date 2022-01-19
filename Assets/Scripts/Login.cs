using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Login : MonoBehaviour
{
	public GameObject username;
	public GameObject password;
	private string Username = "";
	private string Password = "";
    private string UserPassword = "";
    private String[] Lines;

	public void LoginButton()
    {
		bool UN = false;
		bool PW = false;

		if (Username != "")
        {
			if(File.Exists(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt"))
            {
				UN = true;
				Lines = File.ReadAllLines(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt");
			}
            else
            {
				Debug.LogWarning("Username Invaild");
			}
		}
        else
        {
			Debug.LogWarning("Username Field Empty");
		}

		if (Password != "")
        {
			if (File.Exists(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt"))
            {
                if (UserPassword == "")
                {
                    int i = 1;
                    foreach (char c in Lines[4])
                    {
                        i++;
                        UserPassword += c;
                    }

                }

                if (Password == UserPassword)
                {
                    PW = true;
                }

                else
                {
                    Debug.LogWarning("Password Is invalid");
                    password.GetComponent<InputField>().text = "";
                }
                               
            }

            else
            {
				Debug.LogWarning("Password Is invalid");
                password.GetComponent<InputField>().text = "";
            }
		}
        else
        {
			Debug.LogWarning("Password Field Empty");
		}

		if (UN == true && PW == true)
        {
            PlayerPrefs.SetString("name", username.GetComponent<InputField>().text);
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";	
			print ("Login Sucessful");
            Debug.Log("Your name is " + PlayerPrefs.GetString("name"));
            SceneManager.LoadScene("Start Menu");

        }
	}
	
    // Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
			if (username.GetComponent<InputField>().isFocused)
            {
				password.GetComponent<InputField>().Select();
			}

        }
		if (Input.GetKeyDown(KeyCode.Return))
        {
			if (Username != "" && Password != "")
            {
				LoginButton();
			}
		}

		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;	
	}

    public void LoadScene(string name)
    {
        SceneManager.LoadScene("Start Menu");
    }

}
