using UnityEngine;

public abstract class Attack : ScriptableObject
{
    protected HeroController m_CharacterController;
    Camera camera;
    PlayerInput input;

    public bool CoolingDown { get; set; }

    protected virtual void ResetState()
    {
        CoolingDown = false;
    }

    public virtual void InitModule(HeroController a_CharacterController)
    {
        m_CharacterController = a_CharacterController;
        input = a_CharacterController.GetComponentInChildren<PlayerInput>();
        camera = Camera.main;
    }

    public bool shouldAttack()
    {
        return !CoolingDown && shouldAttackInternal();
    }

    protected abstract bool shouldAttackInternal();

    public abstract string GetSpriteState();

    public abstract void doAttack();

    public abstract float getAnimationTime();

    protected Vector3 getAttackDirection()
    {
        Vector3 mousePos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        mousePos.z = 0;

        return mousePos - m_CharacterController.transform.position;
    }

    protected bool isButtonPressed(string buttonName)
    {
        return input.GetButton(buttonName).m_IsPressed;
    }
}
