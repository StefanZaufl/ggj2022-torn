using UnityEngine;

public class Relative : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {		
        if (other.name == "Hero") {
			FindObjectOfType<SceneChanger>().ChangeToWin();
		} else {
			//print("Sister collision with not the Hero");
		}
    }
}
