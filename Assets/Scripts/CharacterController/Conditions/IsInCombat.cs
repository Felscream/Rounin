using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Conditions/Combat/IsInCombat")]
    public class IsInCombat : Condition
    {
        public bool IfEqual;

        public override bool CheckCondition(StateManager state)
        {
            if(!state.Animator.GetBool(state.Hashes.IsInteracting))
                return IfEqual == state.IsInCombat;
            return false;
        }
    }
}

