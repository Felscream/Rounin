using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/AnimMovementForward")]
    public class AnimMovementForward : StateActions
    {
        public StateActions[] StateActions;

        public override void Execute(StateManager states)
        {
            for(int i = 0; i < StateActions.Length; ++i)
            {
                StateActions[i].Execute(states);
            }

            if (states.CanMoveForward)
            {
                states.Animator.SetFloat(states.Hashes.Speed, states.MovementVariables.MoveAmount, 0.1f, states.delta);
            }
            else
            {
                states.Animator.SetFloat(states.Hashes.Speed, 0f, 0.1f, states.delta);
            }
        }
    }
}


