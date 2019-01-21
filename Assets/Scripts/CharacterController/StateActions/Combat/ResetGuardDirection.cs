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
            if(!states.Animator.GetBool(states.Hashes.IsAttacking))
                states.GuardVariables.GuardDirection = Vector2.zero;
        }
    }
}

