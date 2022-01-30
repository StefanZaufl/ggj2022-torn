using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PlayerSound : MonoBehaviour
{
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void playFootstep()
    {
        soundManager.PlayWalkSound();
    }
}
