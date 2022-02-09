using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(ScoreBarHandler.totalTime);
		
		GameObject text = GameObject.Find("TextTime");
		//timeString = String.Format(@"Time : {0:mm\:ss}",ts);
		text.GetComponent<TextMeshProUGUI>().text = ScoreBarHandler.totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
