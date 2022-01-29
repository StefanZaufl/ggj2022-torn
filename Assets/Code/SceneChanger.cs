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
        SceneManager.LoadScene("SampleScene");
    }


    public void ChangeToCredit()
    {
        SceneManager.LoadScene("Credits");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
