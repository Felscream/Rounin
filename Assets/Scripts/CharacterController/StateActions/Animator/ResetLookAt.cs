using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/ResetLookAt")]
    public class ResetLookAt : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.AnimatorHook.LookAtActivated = false;
        }
    }
}

