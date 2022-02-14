using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
		string besttime = PlayerPrefs.GetString("besttime", "No time yet");
		print("highscore: " + highscore);
		GameObject hs = GameObject.Find("TextHighscore");
		hs.GetComponent<TextMeshProUGUI>().text = "Your highscore: " + highscore + " Your best time: "  + besttime;
    }

	/*
    // Update is called once per frame
    void Update()
    {
        
    } */
}
