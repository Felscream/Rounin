using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/HasLanded")]
    public class HasLanded : Condition
    {
        public float HardLandThreshold = 1.5f;
        public float MaxThreshold = 2.2f;
        //public float RollForce = 3f;

        public override bool CheckCondition(StateManager state)
        {
            float timeDifference = Time.realtimeSinceStartup - state.TimeSinceFall;
            if (timeDifference > 0.55f)
            {
                bool result = state.IsGrounded;
                
                if (result)
                {
                    if (timeDifference > HardLandThreshold && timeDifference < MaxThreshold)
                    {
                        if(state.MovementVariables.MoveAmount > 0.3f)
                        {
                            state.Animator.SetBool(state.Hashes.IsInteracting, true);
                            state.Animator.CrossFade(state.Hashes.FallAndRoll, 0.1f);

                        }
                        else
                        {
                            state.Animator.SetBool(state.Hashes.IsInteracting, true);
                            state.Animator.CrossFade(state.Hashes.FallLandHard, 0.1f);
                        }
                    }
                    else if(timeDifference > MaxThreshold)
                    {
                        state.Animator.SetBool(state.Hashes.IsInteracting, true);
                        state.Animator.CrossFade(state.Hashes.FallLandHard, 0.1f);
                    }
                    else
                    {
                        state.Animator.CrossFade(state.Hashes.LandLowVelocity, 0.1f);
                    }
                }
                return result;
            }
            else
            {
                return false;
            }
        }
    }
}

