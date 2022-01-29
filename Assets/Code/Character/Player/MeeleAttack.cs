using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "HeroMeeleAttack", menuName = "Hero/Meele Attack")]
class MeeleAttack : Attack
{
    [SerializeField] float attackCooldownSeconds = 0.5f;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] float attackSpawnDistance = 0.7f;

    SpriteAnimator spriteAnimator;

    //Reset all state when this module gets initialized
    protected override void ResetState()
    {
        base.ResetState();
    }

    public override void InitModule(HeroController a_CharacterController)
    {
        base.InitModule(a_CharacterController);
        spriteAnimator = a_CharacterController.GetComponentInChildren<SpriteAnimator>();
    }

    public override void doAttack()
    {
        Vector2 lastGoodDirection = spriteAnimator.LastGoodDirection;
        float x = lastGoodDirection.x >= 0f ? attackSpawnDistance : -attackSpawnDistance;

        Vector3 attackPosition = spriteAnimator.transform.position + new Vector3(x, 0f, 0f);

        GameObject attackObject = GameObject.Instantiate<GameObject>(attackPrefab, attackPosition, Quaternion.identity);
        DamageDealer damageDealer = attackObject.GetComponent<DamageDealer>();
        damageDealer.DamageSource = m_CharacterController.gameObject;
    }

    protected override bool shouldAttackInternal()
    {
        return isButtonPressed("Meele");
    }

    public override float getAnimationTime()
    {
        return attackCooldownSeconds;
    }

    //Get the name of the animation state that should be playing for this module. 
    public override string GetSpriteState()
    {
        return "MeeleAttack";
    }
}
