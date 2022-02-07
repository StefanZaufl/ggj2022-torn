using UnityEngine;

public class DialogAtStartPositionLevel1 : MonoBehaviour
{
	//private GameObject mf;
    private void OnTriggerEnter(Collider other)
    {
		GameObject db = GameObject.Find("DialogueBox");
		db.GetComponent<CanvasGroup>().alpha = 1;
		
		GameObject text = GameObject.Find("TextStartPosition");
		text.GetComponent<CanvasGroup>().alpha = 1;
		
        //FindObjectOfType<SceneChanger>().ChangeToWin();
    }
	
	void OnTriggerExit(Collider other) 
	{
		//Debug.Log ("Triggered Exit");
		GameObject db = GameObject.Find("DialogueBox");
		db.GetComponent<CanvasGroup>().alpha = 0;
		
		GameObject text = GameObject.Find("TextStartPosition");
		text.GetComponent<CanvasGroup>().alpha = 0;
	}
}
