using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator[] animator;

    protected virtual void Awake()
    {
        animator = GetComponentsInChildren<Animator>(true);
    }

    public void Move(Vector2 obj, int charNum)
    {
        animator[charNum].SetBool(IsMoving, obj.magnitude > .5f);
    }

    public void Damage(int charNum)
    {
        animator[charNum].SetBool(IsDamage, true);
    }

    public void InvincibilityEnd(int charNum)
    {
        animator[charNum].SetBool(IsDamage, false);
    }
}
