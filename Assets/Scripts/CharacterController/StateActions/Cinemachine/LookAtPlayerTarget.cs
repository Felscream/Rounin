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
            if (states.Target != null)
            {
                states.AnimatorHook.LookAtTarget(states.Target.position + Vector3.up * TargetOffset, 1f);
                states.PlayerVariables.CinemachineCamera.combat.LookAt = states.Target;
            }
        }
    }
}

