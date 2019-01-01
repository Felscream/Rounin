using UnityEngine;
using System.Collections;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/AnimIsGrounded")]
    public class AnimIsGrounded : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.Animator.SetBool(states.Hashes.IsGrounded, states.IsGrounded);
        }
    }
}

