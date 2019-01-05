using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Cinemachine/CameraControl")]
    public class CameraControl : StateActions
    {
        public override void Execute(StateManager states)
        {
            CinemachineFreeLook camera = states.PlayerVariables.CinemachineCamera.value;
            if(camera != null)
            {
                camera.m_YAxis.m_InputAxisValue = states.CameraVariables.Vertical;
                camera.m_XAxis.m_InputAxisValue = states.CameraVariables.Horizontal;
            }
        }
    }
}

