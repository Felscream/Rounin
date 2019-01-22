using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/ResetGuardDirection")]
    public class ResetGuardDirection : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.GuardVariables.GuardTimer = 0f;
            if(!states.Animator.GetBool(states.Hashes.IsAttackingHeavy) && !states.Animator.GetBool(states.Hashes.IsAttackingLight))
                states.GuardVariables.GuardDirection = Vector2.zero;
        }
    }
}

