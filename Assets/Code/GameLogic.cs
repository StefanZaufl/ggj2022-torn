using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    /**
    Overall Game Logic
    exit game by esc
    **/

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            if (SceneManager.GetActiveScene().name == "Title"){ Application.Quit(); }
            else { SceneManager.LoadScene("Title"); }
        }
    }
}
