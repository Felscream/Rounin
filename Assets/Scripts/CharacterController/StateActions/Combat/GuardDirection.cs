using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/GuardDirection")]
    public class GuardDirection : StateActions
    {
        public override void Execute(StateManager states)
        {
           
            if(states.CameraVariables.Horizontal != 0f || states.CameraVariables.Vertical > 0f)
            {
                Vector2 dir = Vector2.zero;
                if (Mathf.Abs(states.CameraVariables.Horizontal) > states.CameraVariables.Vertical)
                {
                    if (states.CameraVariables.Horizontal > 0f)
                    {
                        dir.x = 1f;
                    }
                    else if (states.CameraVariables.Horizontal < 0f)
                    {
                        dir.x = -1f;
                    }
                }
                else if(states.CameraVariables.Vertical > 0f)
                {
                    dir.y = 1f;
                }

                if(dir != Vector2.zero)
                {
                    states.GuardVariables.GuardTimer = 0f;
                    states.GuardVariables.GuardDirection = dir;
                }
                else
                {
                    states.GuardVariables.GuardTimer = Mathf.Clamp(states.GuardVariables.GuardTimer + states.delta, 0f, Constants.ResetGuardTime);
                }
                
            }
            else
            {
                states.GuardVariables.GuardTimer = Mathf.Clamp(states.GuardVariables.GuardTimer + states.delta, 0f, Constants.ResetGuardTime);
            }

            if (states.GuardVariables.GuardTimer >= Constants.ResetGuardTime)
            {
                states.GuardVariables.GuardDirection = Vector2.zero;
            }
        }
    }
}


