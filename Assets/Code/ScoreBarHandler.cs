using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using TMPro;

public class ScoreBarHandler : MonoBehaviour
{
	public Stopwatch stopwatch = new Stopwatch();
	private string timeString;
	private string healthString;
	public static string totalTime;
	
    // Start is called before the first frame update
    void Start()
    {
		stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan ts = stopwatch.Elapsed;
		GameObject text = GameObject.Find("TextStopwatch");
		timeString = String.Format(@"Time : {0:mm\:ss}",ts);
		text.GetComponent<TextMeshProUGUI>().text = timeString;
		
		//print(timeString);
		totalTime = timeString;

		GameObject hero = GameObject.Find("Hero");
		float power = hero.GetComponent<DamageReceiver>().Health;
		string powerString = power.ToString();
		//print(powerString);
		//healthString = String.Format("Health : ",powerString);
		GameObject health = GameObject.Find("TextHealth");
		health.GetComponent<TextMeshProUGUI>().text = powerString;
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
