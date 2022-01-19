using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelManager1 : MonoBehaviour
{
    public Transform mainMenu;

    public void Instruction1MenuScene(string name)
    {
        SceneManager.LoadScene("InstructionMenu1");
    }

    public void Instruction2MenuScene(string name)
    {
        SceneManager.LoadScene("InstructionMenu2");
    }
    
    public void Instruction3MenuScene(string name)
    {
        SceneManager.LoadScene("InstructionMenu3");
    }

    public void ThankMenuScene(string name)
    {
        SceneManager.LoadScene("ThankMenu");
    }

    public void VideoScene(string name)
    {
        SceneManager.LoadScene("VideoScene");
    }

    public void VideoScene1(string name)
    {
        SceneManager.LoadScene("VideoScene1");
    }

    public void ConfigurationTemplateScene(string name)
    {
        SceneManager.LoadScene("ConfigurationTemplateScene");
    }

    public void ConfigurationTemplateSceneReal(string name)
    {
        SceneManager.LoadScene("ConfigurationTemplateSceneReal");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }



}
