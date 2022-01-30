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
        if (Input.GetKeyDown("escape"))
        {
            if (SceneManager.GetActiveScene().name == "Title"){ Application.Quit(); }
            else if (SceneManager.GetActiveScene().name == "Credits"){ SceneManager.LoadScene("Title"); }
            else { SceneManager.LoadScene("Title"); SoundManager.instance.FromGameToTitle();}
        }
    }
}
