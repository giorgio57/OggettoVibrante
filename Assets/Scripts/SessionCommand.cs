using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class SessionCommand : MonoBehaviour
{

    public Image EndSession;

    public void Start()
    {
        EndSession.gameObject.SetActive(false);
        //Invoke("EndSessionAppear", 960.0f);
        Invoke("EndSessionAppear", 20.0f);
    }

    public void Update()
    {
        //Invoke("EndSessionAppear", 1.0f);
    }

    public void EndSessionAppear()
    {
        EndSession.gameObject.SetActive(true);
        //SceneManager.LoadScene("InstructionMenu2");
    }

}
