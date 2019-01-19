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
            states.PlayerVariables.GuardTimer = 0f;
            if(!states.Animator.GetBool(states.Hashes.IsAttacking))
                states.PlayerVariables.GuardDirection = Vector2.zero;
        }
    }
}

