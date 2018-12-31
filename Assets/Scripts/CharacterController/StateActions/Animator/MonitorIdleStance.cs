using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Monitor Idle Stance")]
    public class MonitorIdleStance : StateActions
    {
        public float DelayToIdle = 7f;

        private float TimeToIdle = 0f;

        public override void Execute(StateManager states)
        {
            if(states.MovementVariables.MoveAmount > 0.1f)
            {
                TimeToIdle = Time.time + DelayToIdle;
                states.Animator.SetBool(states.Hashes.StandingIdle, false);
            }
            else
            {
                if(Time.time > TimeToIdle)
                {
                    states.Animator.SetBool(states.Hashes.StandingIdle, true);
                }
            }
        }
    }
}

