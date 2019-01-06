using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Monitor Idle Stance")]
    public class MonitorIdleStance : StateActions
    {
        public float DelayToIdle = 7f;

        public float TimeToIdle = 0f;

        public override void Execute(StateManager states)
        {
            if(states.MovementVariables.MoveAmount > 0.1f)
            {
                TimeToIdle = Time.time + DelayToIdle;
                states.Animator.SetBool(states.Hashes.StandingIdle, false);
                states.Animator.applyRootMotion = false;
                states.Animator.transform.localPosition = Vector3.zero;
                states.Animator.transform.localRotation = Quaternion.identity;
            }
            else
            {
                
                if (Time.time > TimeToIdle && (!states.Animator.GetBool(states.Hashes.StandingIdle) || !states.Animator.applyRootMotion ))
                {
                    states.Animator.SetFloat(states.Hashes.IdleRand, Mathf.Round(Random.Range(0f, 1f)));
                    states.Animator.SetBool(states.Hashes.StandingIdle, true);
                    if (!states.Animator.IsInTransition(0))
                    {
                        states.Animator.applyRootMotion = true;
                    }
                }
            }
        }
    }
}

