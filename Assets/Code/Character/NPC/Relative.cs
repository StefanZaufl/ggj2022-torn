using UnityEngine;

public class Relative : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {		
        FindObjectOfType<SceneChanger>().ChangeToWin();
    }
}
