using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using TMPro;
using UnityEngine.UI;

public class ScoreBarHandler : MonoBehaviour
{
	public Stopwatch stopwatch = new Stopwatch();
	private string timeString;
	private string healthString;
	public static string totalTime;
	
	public static int score = 0;
	
    // Start is called before the first frame update
    void Start()
    {
		stopwatch.Start();
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = stopwatch.Elapsed;
		GameObject text = GameObject.Find("TextStopwatch");
		timeString = String.Format(@"Time : {0:mm\:ss}",ts);
		text.GetComponent<TextMeshProUGUI>().text = timeString;
		
		//set totalTime for win screen
		totalTime = timeString;

		GameObject hero = GameObject.Find("Hero");
		float power = hero.GetComponent<DamageReceiver>().Health;
		string powerString = power.ToString();
		GameObject health = GameObject.Find("TextHealth");
		health.GetComponent<TextMeshProUGUI>().text = "Health: " + powerString;
		
		GameObject TextPoints = GameObject.Find("TextPoints");
		TextPoints.GetComponent<TextMeshProUGUI>().text = "Points: " + score.ToString();		
    }

	public static void AddPoints(int scorePoints)
	{
		score += scorePoints;
	}
	
	void onDisable()
	{
		print(timeString);
		totalTime = timeString;
		
	}
	
	void onDestroy()
	{
		print(timeString);
		totalTime = timeString;		
	}
	
}
