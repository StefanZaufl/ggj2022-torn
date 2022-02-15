using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//read values from memory
        int highscore = PlayerPrefs.GetInt("highscore", 0);
		string highscoreTime = PlayerPrefs.GetString("highscoreTime", "No time yet");
		string besttime = PlayerPrefs.GetString("besttime", "No time yet");
		int besttimeScore = PlayerPrefs.GetInt("besttimeScore", 0);
		print("highscore: " + highscore);
		//write values to screen
		GameObject hs = GameObject.Find("TextHighscore");
		string highscoreText = "Your highscore: " + highscore + " at " + highscoreTime;
		string besttimeText = " Your best time: "  + besttime + " with Points: " + besttimeScore;
		hs.GetComponent<TextMeshProUGUI>().text = highscoreText + "\n" + besttimeText;
    }

	/*
    // Update is called once per frame
    void Update()
    {
        
    } */
}
