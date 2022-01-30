using UnityEngine;
using System.Collections;

public class HeroDamageReceiver : DamageReceiver
{
    [SerializeField] float stunnedTime = 0.4f;
    [SerializeField] float gameOverScreenDelay = 3f;

    SoundManager soundManager;

    private void Start()
    {
        init(GetComponent < DeathHandler>());

        soundManager = FindObjectOfType<SoundManager>();
    }

    public bool Stunned { get; private set; }
    public Vector3 LastHitForceNormalized { get; private set; }

    protected override void onHit(Vector3 hitForceNormalized)
    {
        LastHitForceNormalized = hitForceNormalized;
        soundManager.PlayCharacterGetDamageSound();

        if (Alive)
        {
            StartCoroutine(handleStun());
        }
        else
        {
            Stunned = true;
            StartCoroutine(ChangeToGameOver());
        }
    }

    IEnumerator handleStun()
    {
        Stunned = true;
        yield return new WaitForSeconds(stunnedTime);
        Stunned = false;
    }

    IEnumerator ChangeToGameOver()
    {
        yield return new WaitForSeconds(gameOverScreenDelay);
        FindObjectOfType<SceneChanger>().ChangeToLoose();
    }
}
