﻿using System.Collections;
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

            float blend = 0f;
            if(states.MovementVariables.MoveAmount < Constants.RunThreshold)
            {
                if(states.MovementVariables.MoveAmount > Constants.MovementThreshold)
                {
                    blend = 0.13f;
                }
            }
            else
            {
                blend = 1f;
            }
            if (states.CanMoveForward || states.IsInCombat)
            {
                states.Animator.SetFloat(states.Hashes.Speed, blend, 0.1f, states.delta);
                states.Animator.SetFloat(states.Hashes.MoveX, states.MovementVariables.Horizontal, 0.1f, states.delta);
                states.Animator.SetFloat(states.Hashes.MoveY, states.MovementVariables.Vertical, 0.1f, states.delta);
            }
            else
            {
                states.Animator.SetFloat(states.Hashes.Speed, 0f, 0.1f, states.delta);
                states.Animator.SetFloat(states.Hashes.MoveX, 0f, 0.1f, states.delta);
                states.Animator.SetFloat(states.Hashes.MoveY, 0f, 0.1f, states.delta);
            }
        }
    }
}


