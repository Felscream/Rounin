using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(fileName = "SetJump", menuName = "Actions/State Actions/Jump/SetJump")]
    public class AnimJump : StateActions
    {
        public bool Value;
        public override void Execute(StateManager states)
        {
            states.Animator.SetBool(states.Hashes.IsJumping, Value);
            states.TimeSinceJump = Time.realtimeSinceStartup;
        }
    }
}

