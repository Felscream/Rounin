using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Cinemachine/ChangeCameraPriority")]
    public class ChangeCameraPriority : StateActions
    {
        public int MainCameraWeight = 11;
        public int CombatCameraWeight = 10;
        public int RunningCameraWeight = 10;

        public override void Execute(StateManager states)
        {
            states.PlayerVariables.CinemachineCamera.value.Priority = MainCameraWeight;
            states.PlayerVariables.CinemachineCamera.combat.Priority = CombatCameraWeight;
            states.PlayerVariables.CinemachineCamera.running.Priority = RunningCameraWeight;
        }
    }
}

