using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsCheckpoint : MonoBehaviour
{
	    private void OnTriggerEnter(Collider other)
    {
		Analytics.CustomEvent("Checkpoint", new Dictionary<string, object>
		{
			{ "checkpointName", this.gameObject.name }
		});
		
		/*
		try {
			GameObject mf = GameObject.Find("MushroomField");
			mf.SetActive(false);
		} catch {
			//Mushrooms already deactivated
		}
		//Debug.Log ("Triggered Enter");
		
		GameObject db = GameObject.Find("DialogueBox");
		db.GetComponent<CanvasGroup>().alpha = 1;
		
		GameObject text = GameObject.Find("TextMotherMushroomSister");
		text.GetComponent<CanvasGroup>().alpha = 1;
		*/
        //FindObjectOfType<SceneChanger>().ChangeToWin();
    }
}
