using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/LookAtPlayerTarget")]
    public class LookAtPlayerTarget : StateActions
    {
        public override void Execute(StateManager states)
        {
            if (states.Target != null)
            {
                states.PlayerVariables.CinemachineCamera.combat.LookAt = states.Target;
                states.PlayerVariables.CinemachineCamera.combat.Priority = 11;
                states.PlayerVariables.CinemachineCamera.value.Priority = 10;
            }
            else
            {
                states.PlayerVariables.CinemachineCamera.combat.LookAt = states.mTransform;
                states.PlayerVariables.CinemachineCamera.combat.Priority = 10;
                states.PlayerVariables.CinemachineCamera.value.Priority = 11;
            }
        }
    }
}

