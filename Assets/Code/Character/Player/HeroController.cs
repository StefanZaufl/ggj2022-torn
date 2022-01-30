using UnityEngine;
using System.Collections;

public class HeroController : GroundedCharacterController
{
    [SerializeField]
    Attack[] attacks;

    bool isAttacking = false;
    string attackAnimationState;
    HeroDamageReceiver damageReceiver;

    private void Start()
    {
        foreach (Attack attack in attacks)
        {
            attack.InitModule(this);
        }

        damageReceiver = GetComponent<HeroDamageReceiver>();
    }

    protected override string GetCurrentSpriteStateForDefault()
    {
        if (damageReceiver.Alive && isAttacking)
        {
            return attackAnimationState;
        }
        else
        {
            return base.GetCurrentSpriteStateForDefault();
        }
    }

    protected override void UpdateController()
    {
        base.UpdateController();

        if (damageReceiver.Stunned || !damageReceiver.Alive || isAttacking) return;

        foreach(Attack attack in attacks)
        {
            if(attack.shouldAttack())
            {
                StartCoroutine(doAttack(attack));
                break;
            }
        }
    }

    IEnumerator doAttack(Attack attack)
    {
        isAttacking = true;
        attack.doAttack();
        attackAnimationState = attack.GetSpriteState();
        attack.CoolingDown = true;

        yield return new WaitForSeconds(attack.getAnimationTime());

        isAttacking = false;
        attack.CoolingDown = false;
    }
}
