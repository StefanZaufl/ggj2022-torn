using UnityEngine;

public class ToggleMushroomFieldMother : MonoBehaviour
{
	private GameObject mf;
    private void OnTriggerEnter(Collider other)
    {
		
		mf = GameObject.Find("MushroomField");
		mf.SetActive(false);
		
        //FindObjectOfType<SceneChanger>().ChangeToWin();
    }
}
