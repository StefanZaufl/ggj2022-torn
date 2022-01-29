using UnityEngine;
using System.Collections;

class SimpleEnemyController : MonoBehaviour, DeathHandler, HitForceReceiver
{
    [SerializeField] float deathAnimationLength = 0.0f;
    [SerializeField] PhysicsSensor playerSensor;
    [SerializeField] float enemySpeed = 1;
    [SerializeField] bool freezeYMovement = false;
    [SerializeField] float maxVelocity = 2;
    [SerializeField] float hitForce = 40;
    [SerializeField] float stunnedTimer = 1f;

    Rigidbody enemyRigidbody;
    bool stunned = false;
    Coroutine lastStunCoroutine;

    private void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(stunned || !playerSensor.Triggered || enemyRigidbody.velocity.sqrMagnitude > Mathf.Pow(maxVelocity, 2))
        {
            return;
        }

        Vector3 playerPos = playerSensor.LastObjectSeen.transform.position;
        Vector3 direction = playerPos - transform.position;
        direction.z = 0;

        if(freezeYMovement)
        {
            direction.y = 0;
        }

        Vector3 force = direction.normalized * enemySpeed * Time.fixedDeltaTime;
        enemyRigidbody.AddForce(force);
    }

    public void handleDeath()
    {
        if (deathAnimationLength > 0f)
        {
            StartCoroutine(selfDestruct());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(deathAnimationLength);
        
        Destroy(gameObject);
    }

    public void receiveHitForce(Vector3 hitForceNormalized)
    {
        Vector3 force = hitForceNormalized * hitForce;
        enemyRigidbody.AddForce(force);

        if(lastStunCoroutine != null && stunned)
        {
            StopCoroutine(lastStunCoroutine);
        }

        lastStunCoroutine = StartCoroutine(stunEnemy());
    }

    IEnumerator stunEnemy()
    {
        stunned = true;

        yield return new WaitForSeconds(stunnedTimer);

        stunned = false;
    }
}
