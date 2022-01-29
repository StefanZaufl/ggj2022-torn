using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class MeeleAttackModule : GroundedControllerAbilityModule
{
    [SerializeField] float attackCooldownSeconds = 0.5f;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] float attackSpawnDistance = 0.7f;

    bool isAttacking = false;
    bool initAttack = true;
    float cooldown = 0f;
    SpriteAnimator spriteAnimator;
    PlayerInput input;

    //Reset all state when this module gets initialized
    protected override void ResetState()
    {
        base.ResetState();
        isAttacking = false;
        initAttack = true;
        cooldown = 0f;
    }

    public override void InitModule(CharacterControllerBase a_CharacterController)
    {
        base.InitModule(a_CharacterController);
        spriteAnimator = a_CharacterController.GetComponentInChildren<SpriteAnimator>();
        input = a_CharacterController.GetComponentInChildren<PlayerInput>();
    }

    //Execute Attack (lasts as long as the animation)
    //Called for every fixedupdate that this module is active
    public override void FixedUpdateModule()
    {
        if(initAttack)
        {
            initAttack = false;
            isAttacking = true;
            cooldown = attackCooldownSeconds;

            Vector2 lastGoodDirection = spriteAnimator.LastGoodDirection;
            float x = lastGoodDirection.x >= 0f ? attackSpawnDistance : -attackSpawnDistance;

            Vector3 attackPosition = spriteAnimator.transform.position + new Vector3(x, 0f, 0f);

            GameObject.Instantiate<GameObject>(attackPrefab, attackPosition, Quaternion.identity);
            input.setInputLocked(true);
        }

        cooldown -= Time.deltaTime;

        if(cooldown <= 0f)
        {
            isAttacking = false;
            initAttack = true;
            input.setInputLocked(false);
        }
    }

    //Query whether this module can be active, given the current state of the character controller (velocity, isGrounded etc.)
    //Called every frame when inactive (to see if it could be) and when active (to see if it should not be)
    public override bool IsApplicable()
    {
        return isAttacking || (m_ControlledCollider.IsGrounded() && input.GetButton("Meele").m_IsPressed);
    }

    //Get the name of the animation state that should be playing for this module. 
    public override string GetSpriteState()
    {
        return "MeeleAttack";
    }
}
