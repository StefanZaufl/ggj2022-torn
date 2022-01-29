using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyingDamageReceiver : DamageReceiver
{
    HitForceReceiver receiver;

    private void Start()
    {
        receiver = GetComponent<HitForceReceiver>();

        init(GetComponent<DeathHandler>());
    }

    protected override void onHit(Vector3 hitForceNormalized)
    {
        receiver.receiveHitForce(hitForceNormalized);
    }
}
