using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour
{
	public Transform mainMenu;

	public void ConfigurationABidiScene(string name)
    {
        SceneManager.LoadScene("ConfigurationABidi");
    }

    public void ConfigurationBBidiScene(string name)
    {
        SceneManager.LoadScene("ConfigurationBBidi");
    }

    public void ConfigurationCBidiScene(string name)
    {
        SceneManager.LoadScene("ConfigurationCBidi");
    }

    public void ConfigurationACumuScene(string name)
    {
        SceneManager.LoadScene("ConfigurationACumu");
    }

    public void ConfigurationBCumuScene(string name)
    {
        SceneManager.LoadScene("ConfigurationBCumu");
    }

    public void ConfigurationCCumuScene(string name)
    {
        SceneManager.LoadScene("ConfigurationCCumu");
    }

    //public void OfficeScene(string name)
    //{
    //    SceneManager.LoadScene("OfficeScene");
    //}

    //public void TemplateScene(string name)
    //{
    //    SceneManager.LoadScene("TemplateScene");
    //}

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
	


}
