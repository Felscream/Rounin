using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Cinemachine/Recentering")]
    public class CameraRecentering : StateActions
    {
        public bool value = true;
        public override void Execute(StateManager states)
        {
            states.PlayerVariables.CinemachineCamera.value.m_RecenterToTargetHeading.m_enabled = value;
            states.PlayerVariables.CinemachineCamera.value.m_YAxisRecentering.m_enabled = value;

            if (value)
            {
                states.PlayerVariables.CinemachineCamera.value.m_YAxisRecentering.RecenterNow();
                states.PlayerVariables.CinemachineCamera.value.m_RecenterToTargetHeading.RecenterNow();
            }
        }
    }
}

