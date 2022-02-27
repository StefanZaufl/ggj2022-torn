using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    /// <summary>
	/// whether or not it's on
	/// </summary>
	private bool On;

	/// <summary>
	/// The on sprite.
	/// </summary>
	public Sprite OnSprite;

	/// <summary>
	/// The off sprite.
	/// </summary>
	public Sprite OffSprite;

    /// <summary>
	/// The current image.
	/// </summary>
	public Image image;

    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        On = (PlayerPrefsBool.HasBoolKey("Music"))?PlayerPrefsBool.GetBool("Music"):true;
        image.sprite = (On)?OnSprite:OffSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
	//OnPress switch 
	public void ToggleMusic()
	{Debug.Log("SetBool0 On:"+On);
        On = (PlayerPrefsBool.HasBoolKey("Music"))?PlayerPrefsBool.GetBool("Music"):true;
        Debug.Log("SetBool1 On:"+On);
		On = !On;
        image.sprite = (On)?OnSprite:OffSprite;
        Debug.Log("SetBool2 On:"+On);
		PlayerPrefsBool.SetBool("Music",On);
        Debug.Log("SetBool3 On:"+On);

/*
		image.sprite = (On)?OnSprite:OffSprite;

		float v = (On)?1f:0f;
        */
        SoundManager.instance.ToggleMusic();
        //soundManager.ToggleMusic();

        /*
		if (Key == "Music")
		{
			MusicManager.Instance.SetVolume(v);
		}
		else if (Key == "Sound")
		{
			SoundManager.Instance.SetVolume(v);
		}
        */
	}
}
