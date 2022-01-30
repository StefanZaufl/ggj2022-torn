using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundExtension : MonoBehaviour
{
    ControlledCapsuleCollider controllerCollider;
    GroundedCharacterController characterController;
    [SerializeField] float collisionForceThreshold = 0.0f;

    SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        controllerCollider = GetComponentInParent<ControlledCapsuleCollider>();
    }

    void OnEnable()
    {
        characterController = GetComponentInParent<GroundedCharacterController>();
        characterController.OnJump += onJump;
    }


    void OnDisable()
    {
        characterController.OnJump -= onJump;
    }

    void onJump()
    {
        soundManager.PlayJumpSound();
    }

    void FixedUpdate()
    {
        List<CapsuleCollisionOccurrance> cols = controllerCollider.GetCollisionInfo();
        for (int i = 0; i < cols.Count; i++)
        {
            if (cols[i].m_VelocityLossPure.magnitude >= collisionForceThreshold)
            {
                soundManager.PlayLandingSound();
            }
        }
    }


}
