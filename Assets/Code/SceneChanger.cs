using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void ChangeToTitle()
    {
        SceneManager.LoadScene("Title");
    }


    public void ChangeToLevelOne()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<SoundManager>().StartMainTheme();
    }


    public void ChangeToCredit()
    {
        SceneManager.LoadScene("Credits");
    }


    public void ChangeToWin()
    {
        SceneManager.LoadScene("Win");
    }


    public void ChangeToLoose()
    {
        SceneManager.LoadScene("Loose");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
