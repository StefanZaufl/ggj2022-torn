using UnityEngine;

public class VelocityAnimationControl : MonoBehaviour
{
    Animator animator;
    Rigidbody thisRigidbody;

    private void Start()
    {
        animator = GetComponent<Animator>();
        thisRigidbody = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = thisRigidbody.velocity;

        if(velocity.sqrMagnitude > 0.01f)
        {
            velocity = velocity.normalized;
        }
        else
        {
            velocity = Vector2.zero;
        }

        animator.SetFloat("X", velocity.x);
        animator.SetFloat("Y", velocity.y);
    }
}
