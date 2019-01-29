using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Guard;

namespace SA
{
    [CreateAssetMenu(fileName = "PlayParryAnimation", menuName = "Actions/State Actions/Combat/PlayParryAnimation" )]
    public class PlayParryAnimation : StateActions
    {
        public override void Execute(StateManager states)
        {
            switch (states.GuardVariables.ParryData.Parry)
            {
                case ParryType.FrontUp:
                    {
                        states.Animator.CrossFade(states.Hashes.ParryFrontUp, 0.1f);
                    }
                    break;
                case ParryType.FrontLeft:
                    {
                        states.Animator.CrossFade(states.Hashes.ParryFrontLeft, 0.1f);
                    }
                    break;
                case ParryType.FrontRight:
                    {
                        states.Animator.CrossFade(states.Hashes.ParryFrontRight, 0.1f);
                    }
                    break;
                case ParryType.Right:
                    {
                        states.Animator.CrossFade(states.Hashes.ParryRight, 0.1f);
                    }
                    break;
                case ParryType.Left:
                    {
                        states.Animator.CrossFade(states.Hashes.ParryLeft, 0.1f);
                    }
                    break;
                default:
                    {
                        states.Animator.CrossFade(states.Hashes.ParryFrontUp, 0.1f);
                    }
                    break;
            }
            states.Animator.SetBool(states.Hashes.IsInteracting, true);
        }
    }
}

