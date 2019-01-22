using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/Combat/IsAttackingHeavy")]
    public class IsAttackingHeavy : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.Animator.GetBool(state.Hashes.IsAttackingHeavy);
        }
    }
}

