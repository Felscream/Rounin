using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Cinemachine/ChangeCameraUpdateMethod")]
    public class CinemachineUpdateChange : StateActions
    {
        public Cinemachine.CinemachineBrain.UpdateMethod UpdateMethod;

        public override void Execute(StateManager states)
        {
            states.PlayerVariables.CinemachineBrain.value.m_UpdateMethod = UpdateMethod;
        }
    }
}

