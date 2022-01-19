using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

public class Register : MonoBehaviour
{   
    //ChatBoxManager chat = new ChatBoxManager();
    public GameObject username;
	public GameObject dateOfBirth;
    public GameObject nameReal;
    public GameObject surname;
    public GameObject password;
	public GameObject confPassword;
	private string Username;
	private string DateofBirth;
    private string Name;
    private string Surname;
    private string Password;
	private string ConfPassword;
	private string form;
	
	public void RegisterButton()
    {
		bool UN = false;
		bool DB = false;
        bool N = false;
        bool S = false;
		bool PW = false;
		bool CPW = false;

		if (Username != "")
        {
			if (!File.Exists(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt"))
            {
				UN = true;

            }
            else
            {
			    Debug.LogWarning("Username Taken");
			}
		}
        else
        {
			Debug.LogWarning("Username field Empty");
            //chat.SendMessageToChat("Username field Empty");

        }

        if (DateofBirth != "")
        {
            DB = true;
        }
        else
        {
            Debug.LogWarning("Date of Birth field Empty");
        }

        if (Name != "")
        {
            N = true;
        }
        else
        {
            Debug.LogWarning("Name field Empty");
        }

        if (Surname != "")
        {
            S = true;
        }
        else
        {
            Debug.LogWarning("Surname field Empty");
        }

        if (Password != "")
        {
			if(Password.Length > 5)
            {
				PW = true;
			}
            else
            {
				Debug.LogWarning("Password must be at least 6 Characters long");
			}
		}
        else
        {
			Debug.LogWarning("Password field Empty");
		}

		if (ConfPassword != "")
        {
			if (ConfPassword == Password)
            {
				CPW = true;
			}
            else
            {
				Debug.LogWarning("Passwords Don't Match");
			}
		}
        else
        {
			Debug.LogWarning("Confirm Password Field Empty");
		}

		if (UN == true && DB == true && N == true && S == true && PW == true && CPW == true)
        {
			form = (Username + Environment.NewLine + DateofBirth + Environment.NewLine + Name + Environment.NewLine + Surname + Environment.NewLine + Password);

            if (!File.Exists(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt"))
            {
                File.WriteAllText(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt", form);
            }

			username.GetComponent<InputField>().text = "";
			dateOfBirth.GetComponent<InputField>().text = "";
            nameReal.GetComponent<InputField>().text = "";
            surname.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
			confPassword.GetComponent<InputField>().text = "";
			print ("Registration Complete");
		}
        else
        {
            File.Delete(Application.streamingAssetsPath + "/Profiles/" + Username + ".txt");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Tab))
        {
			if (username.GetComponent<InputField>().isFocused)
            {
				dateOfBirth.GetComponent<InputField>().Select();
			}
			if (dateOfBirth.GetComponent<InputField>().isFocused)
            {
				nameReal.GetComponent<InputField>().Select();
			}
            if (nameReal.GetComponent<InputField>().isFocused)
            {
                surname.GetComponent<InputField>().Select();
            }
            if (surname.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
				confPassword.GetComponent<InputField>().Select();
			}
		}

		if (Input.GetKeyDown(KeyCode.Return))
        {
			if (Password != "" && DateofBirth != "" && Name != "" && Surname != "" && Password != "" && ConfPassword != "")
            {
				RegisterButton();
			}
		}
		Username = username.GetComponent<InputField>().text;
		DateofBirth = dateOfBirth.GetComponent<InputField>().text;
        Name = nameReal.GetComponent<InputField>().text;
        Surname = surname.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
		ConfPassword = confPassword.GetComponent<InputField>().text;
	}
}
