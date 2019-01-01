using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateBool : StateMachineBehaviour
{
    public string TargetBool;
    public bool status;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        animator.SetBool(TargetBool, status);
    }
}
