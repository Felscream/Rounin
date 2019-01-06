using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Cinemachine/Recentering")]
    public class CameraRecentering : StateActions
    {
        
        public override void Execute(StateManager states)
        {
            bool value = states.MovementVariables.MoveAmount < Constants.MovementThreshold;

            states.PlayerVariables.CinemachineCamera.value.m_YAxisRecentering.m_enabled = value;
            states.PlayerVariables.CinemachineCamera.value.m_RecenterToTargetHeading.m_enabled = value;
            
        }
    }
}

