using UnityEngine;

public class Relative : MonoBehaviour
{
	public GameObject mf;
    private void OnTriggerEnter(Collider other)
    {
		
		mf = GameObject.Find("MushroomField");
		mf.SetActive(false);
		
        //FindObjectOfType<SceneChanger>().ChangeToWin();
    }
}
