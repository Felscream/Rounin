using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/WaitForAttackToEnd")]
    public class WaitForAttackToEnd : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return !state.Animator.GetBool(state.Hashes.IsAttackingHeavy) && !state.Animator.GetBool(state.Hashes.IsAttackingLight);
        }
    }
}

