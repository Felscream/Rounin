using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/MonitorCombat")]
    public class MonitorCombat : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.IsInCombat = states.InputVariables.LeftTrigger > Constants.CombatThreshold;
            states.Animator.SetBool(states.Hashes.CombatMode, states.IsInCombat);
        }
    }
}

