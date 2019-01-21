using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/MoveGuard")]
    public class MoveGuard : StateActions
    {

        public override void Execute(StateManager states)
        {
            states.Animator.SetBool(states.Hashes.GuardOn, states.GuardVariables.GuardDirection != Vector2.zero);

            if(states.GuardVariables.GuardDirection.x == 1f)
            {
                states.Animator.CrossFade(states.Hashes.RightStance, .5f);
            }
        }
    }
}

