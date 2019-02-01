using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/HasLandedFromJump")]
    public class HasLandedFromJump : Condition
    {
        public float RollThreshold = 1.5f;

        public override bool CheckCondition(StateManager state)
        {
            float timeDifference = Time.realtimeSinceStartup - state.TimeSinceJump;
            bool result = state.IsGrounded;

            if (result)
            {
                if (timeDifference > RollThreshold)
                {
                    state.Animator.SetBool(state.Hashes.IsInteracting, true);
                    state.Animator.CrossFade(state.Hashes.FallAndRoll, 0.1f);
                }
            }
            return result;
        }
    }
}

