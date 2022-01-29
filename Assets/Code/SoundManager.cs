using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /**
    Use SoundManager:
    FindObjectOfType<SoundManager>().functionToCall();
    **/

    // sound sources
    public AudioSource dark_theme;
    public AudioSource light_theme;
    public AudioSource jump;

    // instance this manager
    public static SoundManager instance;


    void Awake()
    {
        // do not destroy this object if scenes are swapped and ensure single instance

        // single instance
        if (instance == null){ instance = this; }
        else { Destroy(gameObject); return; }

        // do not destroy
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        // start with theme
        dark_theme.Play();
    }


    void ChangeMainTheme(bool dark_world)
    {   
        // dark world
        if (dark_world) { light_theme.Stop(); dark_theme.Play(); }
    }


    void PlayJumpSound()
    {
        jump.Play();
    }
}
