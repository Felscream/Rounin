using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/Dodge")]
    public class Dodge : StateActions
    {
        public override void Execute(StateManager states)
        {
            bool interacting = states.Animator.GetBool(states.Hashes.IsInteracting);
            if (states.InputVariables.ADown)
            {
                if (!interacting)
                {
                    states.Animator.SetBool(states.Hashes.IsInteracting, true);
                    states.Animator.applyRootMotion = true;
                }
            }
            else if (interacting)
            {

            }
        }
    }
}

