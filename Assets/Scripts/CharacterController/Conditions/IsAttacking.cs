using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/Combat/IsAttacking")]
    public class IsAttacking : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.Animator.GetBool(state.Hashes.IsAttacking);
        }
    }
}

