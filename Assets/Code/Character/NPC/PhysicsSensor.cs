using UnityEngine;
using System.Collections;

class PhysicsSensor : MonoBehaviour
{
    public bool Triggered { get; private set; }
    public Collider LastObjectSeen { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        LastObjectSeen = other;
        Triggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Triggered = false;
    }
}
