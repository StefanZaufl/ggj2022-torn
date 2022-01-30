using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionAwareGameObject : MonoBehaviour
{
    [SerializeField] WorldType isActiveInWorld;

    private void Start()
    {
        worldChanged(DimensionalShiftManager.Instance.WorldType);
    }

    private void OnEnable()
    {
        DimensionalShiftManager.worldChangedEvent += worldChanged;
    }

    private void OnDisable()
    {
        DimensionalShiftManager.worldChangedEvent -= worldChanged;
    }

    void worldChanged(WorldType newType)
    {
        bool active = isActiveInWorld == newType;
        
        MonoBehaviour[] allScripts = GetComponentsInChildren<MonoBehaviour>();
        foreach(MonoBehaviour script in allScripts)
        {
            if(script != this)
                script.enabled = active;
        }

        Renderer[] allRenderers = GetComponentsInChildren<Renderer>();
        foreach(Renderer renderer in allRenderers) {
            renderer.enabled = active;
        }

        Collider[] allColliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in allColliders)
        {
            collider.enabled = active;
        }

        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            if(enabled)
            {
                rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}
