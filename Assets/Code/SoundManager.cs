using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    /**
    Use SoundManager:
    FindObjectOfType<SoundManager>().functionToCall();
    **/

    // sound sources

    // themes
    public AudioSource menu_theme;
    public AudioSource light_theme;
    public AudioSource dark_theme;

    // jingles
    public AudioSource jingle_win;
    public AudioSource jingle_loose;

    // character
    public AudioSource walk;
    public AudioSource jump;
    public AudioSource landing;
    public AudioSource character_get_damage;
    public AudioSource attack_melee;
    public AudioSource attack_distance;

    // enemy
    public AudioSource enemy_get_damage;

    // npcs
    public AudioSource find_relatives;

    // instance this manager
    public static SoundManager instance;

     AudioSource[] sources;
    
    /// <summary>
	/// whether or not it's on
	/// </summary>
	private bool On;

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
        // start level or menu theme
        if(MusicOn())
        {
            if (SceneManager.GetActiveScene().name == "Level1") StartCoroutine(FadeIn(light_theme, 2.0f));
            else StartCoroutine(FadeIn(menu_theme, 2.0f));
        }
    }

    private bool MusicOn(){
        On = (PlayerPrefsBool.HasBoolKey("Music"))?PlayerPrefsBool.GetBool("Music"):true;
        Debug.Log("On:"+On);
        return On;
    }

    public void ToggleMusic(){
        if(!MusicOn())
        {
            //Get every single audio sources in the scene.
            sources = GameObject.FindSceneObjectsOfType(typeof(AudioSource)) as AudioSource[]; 
            foreach(AudioSource audioSource in sources)
            {
                if(audioSource.isPlaying) 
                {
                    Debug.Log(audioSource.name+" is playing "+audioSource.clip.name);
                    audioSource.Stop();
                    //FadeOut(AudioSource s1, float fade_time)
                    //FadeOut(audioSource, 1f);
                }
            }
            Debug.Log("---------------------------"); //to avoid confusion next time
            //Debug.Break(); //pause the editor
        }
        else
        {
            Start();
        }
    }

    public void FromGameToTitle()
    {
        if(MusicOn())
        {
            if (light_theme.isPlaying) light_theme.Stop();
            if (dark_theme.isPlaying) dark_theme.Stop();
            if (!menu_theme.isPlaying) menu_theme.Play();
            menu_theme.volume = 1.0f;
        }
    }


    public void StartMainTheme()
    {
        if(MusicOn())
        {
            // stop menu theme
            if (menu_theme.isPlaying) { StartCoroutine(FadeOutFadeIn(menu_theme, light_theme, 0.5f, 2.0f)); }
            else { StartCoroutine(FadeIn(light_theme, 2.0f)); }
        }
    }


    public void ChangeMainTheme(WorldType new_world_type)
    {   
        if(MusicOn())
        {
            // stop menu theme
            if (menu_theme.isPlaying) { menu_theme.Stop(); }

            // dark world / light world fade
            if (new_world_type == WorldType.DARK) { StartCoroutine(FadeBetween(light_theme, dark_theme, 5.0f)); }
            else { StartCoroutine(FadeBetween(dark_theme, light_theme, 5.0f)); }
        }
    }


    private IEnumerator FadeOutFadeIn(AudioSource s1, AudioSource s2, float fade_in_time, float fade_out_time)
    {
        float t = 0.0f;

        // init sound
        s2.volume = 0.0f;
        s2.Play();

        // fading
        while (t < fade_in_time + fade_out_time)
        {
            // fading
            if (t < fade_in_time) { s1.volume = Mathf.Lerp(1, 0, t / fade_in_time); }
            else { s2.volume = Mathf.Lerp(0, 1, (t - fade_in_time ) / fade_out_time); }

            // update time
            t += Time.deltaTime;

            // have to be there
            yield return null;
        }

        // stop sound 1
        s1.Stop();
    }


    private IEnumerator FadeIn(AudioSource s1, float fade_time)
    {
        float t = 0.0f;

        // delete this line later, now its quite nice to have
        Debug.Log("fade in to " + s1);


        // change track
        s1.volume = 0.0f;
        s1.Play();

        // fading in
        while (t < fade_time)
        {
            // fading out
            s1.volume = Mathf.Lerp(0, 1, t / fade_time);

            // update time
            t += Time.deltaTime;

            // have to be there
            yield return null;
        }
    }


    private IEnumerator FadeOut(AudioSource s1, float fade_time)
    {
        float t = 0.0f;

        // delete this line later, now its quite nice to have
        Debug.Log("fade out from " + s1);

        // fading out
        while (t < fade_time)
        {
            // fading out
            s1.volume = Mathf.Lerp(1, 0, t / fade_time);

            // update time
            t += Time.deltaTime;

            // have to be there
            yield return null;
        }

        // change track
        s1.Stop();
    }


    private IEnumerator FadeBetween(AudioSource s1, AudioSource s2, float fade_time)
    {
        /**
        fade from s1 to s2 in fade time
        **/

        //light_theme.Stop(); 
        //dark_theme.Play();
        float t = 0.0f;

        // init sound
        s2.volume = 0.0f;
        s2.Play();

        // delete this line later, now its quite nice to have
        Debug.Log("fade to " + s2);

        // fading
        while (t < fade_time)
        {
            // fading
            s1.volume = Mathf.Lerp(1, 0, t / fade_time);
            s2.volume = Mathf.Lerp(0, 1, t / fade_time);

            // update time
            t += Time.deltaTime;

            // have to be there
            yield return null;
        }

        // stop sound 1
        s1.Stop();
    }


    public void PlayWalkSound()
    {   
        // ask if sound finished, then play
        if (!walk.isPlaying)
        {
            // pitch shift
            walk.pitch = 1.0f + Random.Range(-0.1f, 0.1f);
            walk.Play();
        }
    }


    // jingles, ToDo fading
    public void PlayWinJingle()
    { 
        if (light_theme.isPlaying) light_theme.Stop();
        if (dark_theme.isPlaying) dark_theme.Stop();
        if (!jingle_win.isPlaying) jingle_win.Play();
    }

    public void PlayLooseJingle()
    { 
        if (light_theme.isPlaying) light_theme.Stop();
        if (dark_theme.isPlaying) dark_theme.Stop();
        if (!jingle_loose.isPlaying) jingle_loose.Play();
    }

    // simple sounds oneliner
    public void PlayJumpSound(){ if (!jump.isPlaying){ jump.Play(); } }
    public void PlayLandingSound(){ if (!landing.isPlaying){ landing.Play(); } }
    public void PlayCharacterGetDamageSound(){ if (!character_get_damage.isPlaying){ character_get_damage.Play(); } }
    public void PlayAttackMeleeSound(){
        if (attack_melee.isPlaying)
        {
            attack_melee.Stop();
        }

        attack_melee.Play();
    }
    public void PlayAttackDistanceSound()
    {
        if (attack_distance.isPlaying)
        {
            attack_distance.Stop();
        }

        attack_distance.Play();
    }
    
    // enemy
    public void PlayEnemyGetDamageSound(){ if (!enemy_get_damage.isPlaying){ enemy_get_damage.Play(); } }
    
    // npcs
    public void PlayFindRelativesSound(){ if (!find_relatives.isPlaying){ find_relatives.Play(); } }
}
