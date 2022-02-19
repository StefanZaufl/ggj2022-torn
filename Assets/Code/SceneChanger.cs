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
        SoundManager.instance.StartMainTheme();
    }


    public void ChangeToCredit()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ChangeToHighscore()
    {
        SceneManager.LoadScene("Highscore");
    }
	
    public void ChangeToWin()
    {
        SceneManager.LoadScene("Win");
        SoundManager.instance.PlayWinJingle();
    }


    public void ChangeToLoose()
    {
        SceneManager.LoadScene("Loose");
        SoundManager.instance.PlayLooseJingle();
    }


    public void ChangeToStory()
    {
        SceneManager.LoadScene("Story");
        SoundManager.instance.StartMainTheme();
    }
	
	public void ChangeToLevels()
    {
        SceneManager.LoadScene("Levels");
    }

	public void ChangeToTraining()
    {
        SceneManager.LoadScene("Training");
    }
	
    public void ExitGame()
    {
        Application.Quit();
    }
}
