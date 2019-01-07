using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/ResetTarget")]
    public class ResetTarget : StateActions
    {
        public override void Execute(StateManager states)
        {
            if(!states.IsDodging)
            {
                states.Target = null;
                states.PlayerVariables.CinemachineCamera.combat.LookAt = states.mTransform;
                states.PlayerVariables.CinemachineCamera.combat.Priority = 10;
                states.PlayerVariables.CinemachineCamera.value.Priority = 11;
            }
            
        }
    }
}

