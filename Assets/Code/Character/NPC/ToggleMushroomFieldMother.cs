using UnityEngine;

public class ToggleMushroomFieldMother : MonoBehaviour
{
	//private GameObject mf;
    private void OnTriggerEnter(Collider other)
    {
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
		
        //FindObjectOfType<SceneChanger>().ChangeToWin();
    }
	
	void OnTriggerExit(Collider other) 
	{
		//Debug.Log ("Triggered Exit");
		GameObject db = GameObject.Find("DialogueBox");
		db.GetComponent<CanvasGroup>().alpha = 0;
		
		GameObject text = GameObject.Find("TextMotherMushroomSister");
		text.GetComponent<CanvasGroup>().alpha = 0;
	}
}
