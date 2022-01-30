using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyingDamageReceiver : DamageReceiver
{
    HitForceReceiver receiver;
    SoundManager soundManager;

    private void Start()
    {
        receiver = GetComponent<HitForceReceiver>();
        soundManager = FindObjectOfType<SoundManager>();

        init(GetComponent<DeathHandler>());
    }

    protected override void onHit(Vector3 hitForceNormalized)
    {
        receiver.receiveHitForce(hitForceNormalized);
        soundManager.PlayEnemyGetDamageSound();
    }
}
