using UnityEngine;

public class DialogueBoxHandler : MonoBehaviour
{
	public string DialogueBoxToHandle;
	public string TextMeshProObjectToShow;
	
    private void OnTriggerEnter(Collider other)
    {
		GameObject db = GameObject.Find(DialogueBoxToHandle);
		db.GetComponent<CanvasGroup>().alpha = 1;
		
		GameObject text = GameObject.Find(TextMeshProObjectToShow);
		text.GetComponent<CanvasGroup>().alpha = 1;
		
        //FindObjectOfType<SceneChanger>().ChangeToWin();
    }
	
	void OnTriggerExit(Collider other) 
	{
		//Debug.Log ("Triggered Exit");
		GameObject db = GameObject.Find(DialogueBoxToHandle);
		db.GetComponent<CanvasGroup>().alpha = 0;
		
		GameObject text = GameObject.Find(TextMeshProObjectToShow);
		text.GetComponent<CanvasGroup>().alpha = 0;
	}
}
