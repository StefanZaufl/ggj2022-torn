using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HitForceReceiver
{
    void receiveHitForce(Vector3 hitForceNormalized);
}