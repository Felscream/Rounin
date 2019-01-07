using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/LookAtPlayerTarget")]
    public class LookAtPlayerTarget : StateActions
    {
        public float TargetOffset = 1.5f;
        public override void Execute(StateManager states)
        {
            AxisState.Recentering ast = states.PlayerVariables.CinemachineCamera.value.m_RecenterToTargetHeading;
            ast.m_enabled = true;
            ast.RecenterNow();
            if (states.Target != null)
            {
                states.AnimatorHook.LookAtTarget(states.Target.position + Vector3.up * TargetOffset, 1f);
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

