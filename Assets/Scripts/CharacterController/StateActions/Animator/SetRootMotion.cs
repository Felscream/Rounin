using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/SetRootMotion")]
    public class SetRootMotion : StateActions
    {
        public bool status;
        public override void Execute(StateManager states)
        {
            states.Animator.applyRootMotion = status;
        }
    }
}


