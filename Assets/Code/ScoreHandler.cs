using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		GameObject text = GameObject.Find("TextTime");
		//timeString = String.Format(@"Time : {0:mm\:ss}",ts);
		text.GetComponent<TextMeshProUGUI>().text = "Time: " + ScoreBarHandler.totalTime;
		
		print("ScoreBarHandler.score: " + ScoreBarHandler.score);
		Scene scene = SceneManager.GetActiveScene();
		print("scene.name: " + scene.name);
		if (scene.name == "Win")
		{
			setHighscore();
		}
		
		GameObject tp = GameObject.Find("TextPoints");
		tp.GetComponent<TextMeshProUGUI>().text = "Points: " + ScoreBarHandler.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void setHighscore()
	{
		//read highscore from memory
		int memHighscore = PlayerPrefs.GetInt("highscore", 0);
		print("memHighscore: " + memHighscore);

		//read besttime from memory and convert
		string memBesttime = PlayerPrefs.GetString("besttime", "23:59");
		print("memBesttime: " + memBesttime);
		TimeSpan tsMemBesttime = TimeSpan.Parse(memBesttime);
		
		//write highscore to memory
		if (ScoreBarHandler.score >= memHighscore) 
		{	
			PlayerPrefs.SetInt("highscore", ScoreBarHandler.score);
			PlayerPrefs.SetString("highscoreTime", ScoreBarHandler.totalTime);			
		}
		
		//convert and write besttime to memory
		TimeSpan tsBesttime = TimeSpan.Parse(ScoreBarHandler.totalTime);
		if (TimeSpan.Compare(tsBesttime,tsMemBesttime)<1)
		{
			PlayerPrefs.SetString("besttime", ScoreBarHandler.totalTime);
			PlayerPrefs.SetInt("besttimeScore", ScoreBarHandler.score);
		}
	}
}
