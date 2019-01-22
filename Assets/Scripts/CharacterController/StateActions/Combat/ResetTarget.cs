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
            if (!states.IsDodging && !states.Animator.GetBool(states.Hashes.IsAttackingHeavy) && !states.Animator.GetBool(states.Hashes.IsAttackingLight))
            {
                states.Target = null;
                states.PlayerVariables.CinemachineCamera.combat.LookAt = states.PlayerVariables.CombatDefaultTarget;
            }
            
        }
    }
}

