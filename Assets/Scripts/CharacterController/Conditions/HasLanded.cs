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
        
        public override bool CheckCondition(StateManager state)
        {
            float timeDifference = Time.realtimeSinceStartup - state.TimeSinceFall;
            if (timeDifference > 0.5f)
            {
                bool result = state.IsGrounded;

                if (result)
                {
                    Debug.Log(timeDifference);
                    if(timeDifference > HardLandThreshold && timeDifference < MaxThreshold)
                    {
                        if(state.MovementVariables.MoveAmount > 0.3f)
                        {
                            state.Animator.CrossFade(state.Hashes.FallAndRoll, 0.2f);
                        }
                        else
                        {
                            state.Animator.CrossFade(state.Hashes.FallLandHard, 0.2f);
                        }
                    }
                    else if(timeDifference > MaxThreshold)
                    {
                        state.Animator.CrossFade(state.Hashes.FallLandHard, 0.2f);
                    }
                    else
                    {
                        state.Animator.CrossFade(state.Hashes.LandLowVelocity, 0.2f);
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

