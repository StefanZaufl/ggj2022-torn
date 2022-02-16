using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsWinEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Analytics.CustomEvent("Win");
    }
/*
    // Update is called once per frame
    void Update()
    {
        
    }
	*/
}
