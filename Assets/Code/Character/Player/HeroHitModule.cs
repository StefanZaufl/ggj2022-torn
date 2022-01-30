using UnityEngine;

class HeroHitModule : GroundedControllerAbilityModule
{
    [SerializeField] float initialHitSpeed = 40f;
    [SerializeField] float hitSpeedDegenerationPerSecond = 40f;
    [SerializeField] float gravity = 3f;

    Vector3 hitDirection;
    float hitSpeed;
    HeroDamageReceiver damageReceiver;

    public override void InitModule(CharacterControllerBase a_CharacterController)
    {
        base.InitModule(a_CharacterController);
        damageReceiver = a_CharacterController.GetComponent<HeroDamageReceiver>();
    }
    protected override void ResetState()
    {
        base.ResetState();
        hitDirection = Vector3.zero;
        hitSpeed = 0.0f;
    }

    protected override void StartModuleImpl()
    {
        hitSpeed = initialHitSpeed;
        hitDirection = damageReceiver.LastHitForceNormalized;
    }

    public override void FixedUpdateModule()
    {
        hitSpeed -= hitSpeedDegenerationPerSecond * Time.fixedDeltaTime;

        if(hitSpeed < 0f)
        {
            hitSpeed = 0f;
        }

        Vector3 newVel = hitDirection * hitSpeed + Vector3.down * gravity;
        m_ControlledCollider.UpdateWithVelocity(newVel);
    }

    //Query whether this module can be active, given the current state of the character controller (velocity, isGrounded etc.)
    //Called every frame when inactive (to see if it could be) and when active (to see if it should not be)
    public override bool IsApplicable()
    {
        return damageReceiver.Stunned;
    }

    public override string GetSpriteState()
    {
        if(damageReceiver.Alive)
        {
            return "Hit";
        }
        else
        {
            return "Dead";
        }
    }
}
