using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Conditions/CheckMovementDirection")]
    public class CheckMovementDirection : Condition
    {
        public string TargetAnimation;
        public State WaitForAnimationState;
        public override bool CheckCondition(StateManager state)
        {
            bool result = false;
         
            MovementVariables mv = state.MovementVariables;
            if(mv.MoveAmount > Constants.MovementThreshold)
            {
                float angle = Vector3.Dot(mv.MoveDirection, state.mTransform.forward);
                if(angle < 0f)
                {

                    state.Animator.SetBool(state.Hashes.IsInteracting, true);
                    state.Animator.CrossFade(TargetAnimation, 0.2f);
                    state.currentState = WaitForAnimationState;
                    state.Animator.applyRootMotion = true;
                }
            }
            return result;
        }
    }
}


