using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    private static readonly int IsDamage = Animator.StringToHash("IsDamage");

    protected Animator[] player_animator;
    protected Animator[] rider_animator;

    protected virtual void Awake()
    {
        Transform mainSprites = this.gameObject.transform.GetChild(0);
        player_animator = mainSprites.GetComponentsInChildren<Animator>(true);

        Transform rideSprites = this.gameObject.transform.GetChild(1);
        rider_animator = rideSprites.GetComponentsInChildren<Animator>(true);

    }

    public void Move(Vector2 obj, int charNum)
    {
        player_animator[charNum].SetBool(IsMoving, obj.magnitude > .5f);
        if (rider_animator[0].gameObject.activeSelf)
        {
            rider_animator[0].SetBool(IsMoving, obj.magnitude > .5f);
        }
    }

    public void Damage(int charNum)
    {
        player_animator[charNum].SetBool(IsDamage, true);
    }

    public void InvincibilityEnd(int charNum)
    {
        player_animator[charNum].SetBool(IsDamage, false);
    }
}
