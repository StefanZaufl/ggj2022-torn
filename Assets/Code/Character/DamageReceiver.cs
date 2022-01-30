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
        private set
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

    protected void init(DeathHandler deathHandler)
    {
        this.deathHandler = deathHandler;
    }

    void Start()
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (invincible) return;

        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null && damageDealer.Damage > 0f)
        {
            LastDamageDealer = damageDealer;
            Health -= damageDealer.Damage;

            if(Health > 0f && invincibleTimeAfterHit > 0f)
            {
                StartCoroutine(handleInvincibility());
            }

            Vector3 otherPos;

            if(damageDealer.DamageSource != null)
            {
                otherPos = damageDealer.DamageSource.transform.position;
            } else
            {
                otherPos = damageDealer.transform.position;
            }

            Vector3 hitVector = transform.position - otherPos;

            onHit(hitVector.normalized);
        }
    }

    protected virtual void onHit(Vector3 hitForceNormalized)
    {
        //Do nothing
    }

    private IEnumerator handleInvincibility()
    {
        invincible = true;

        yield return new WaitForSeconds(invincibleTimeAfterHit);

        invincible = false;
    }

    public bool Invincible { get { return invincible; } }

    public bool Alive { get { return health > 0f; } }

    public DamageDealer LastDamageDealer { get; private set; }
}
