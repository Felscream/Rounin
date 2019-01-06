using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/Dodge")]
    public class Dodge : StateActions
    {
        public override void Execute(StateManager state)
        {
            bool interacting = state.Animator.GetBool(state.Hashes.IsInteracting);
            if (state.InputVariables.ADown)
            {
                Debug.Log("Started dodging");
                if (!interacting)
                {
                    if (Mathf.Abs(state.MovementVariables.Horizontal) <= Mathf.Abs(state.MovementVariables.Vertical))
                    {
                        state.Animator.SetFloat(state.Hashes.DodgeX, 0f);
                        state.Animator.SetFloat(state.Hashes.DodgeY, state.MovementVariables.Vertical > 0 ? 1f : -1f);
                    }
                    else
                    {
                        state.Animator.SetFloat(state.Hashes.DodgeX, state.MovementVariables.Horizontal > 0 ? 1f : -1f);
                        state.Animator.SetFloat(state.Hashes.DodgeY, 0f);
                    }
                    state.Animator.CrossFade(state.Hashes.Dodge, 0.2f);
                    state.IsDodging = true;
                }
            }
            else
            {
                state.IsDodging = false;
            }
        }
    }
}

