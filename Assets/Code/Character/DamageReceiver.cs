using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float invincibleTimeAfterHit = 0.5f;
    DeathHandler deathHandler;
    bool invincible = false;

    public float Health
    {
        get { return health; }
        set
        {
            if (health > 0f && value <= 0f)
            {
                health = 0f;
                
                if(deathHandler != null)
                    deathHandler.handleDeath();
            }
            else if (value > 0f)
            {
                health = value;
            }
        }
    }

    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (invincible) return;

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null && damageDealer.Damage > 0f)
        {
            Health -= damageDealer.Damage;

            if(Health > 0f && invincibleTimeAfterHit > 0f)
            {
                StartCoroutine(handleInvincibility());
            }

            Vector3 hitVector = transform.position - damageDealer.transform.position;

            onHit(hitVector.normalized);
        }
    }

    protected void onHit(Vector3 hitForceNormalized)
    {
        //Do nothing
    }

    private IEnumerator handleInvincibility()
    {
        invincible = true;

        yield return new WaitForSeconds(invincibleTimeAfterHit);

        invincible = false;
    }
}
