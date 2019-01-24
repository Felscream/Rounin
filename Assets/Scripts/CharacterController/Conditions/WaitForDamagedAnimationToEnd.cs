using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/WaitForDamagedAnimationToEnd")]
    public class WaitForDamagedAnimationToEnd : Condition
    {
        public bool ToCombat;

        public override bool CheckCondition(StateManager state)
        {
            if (ToCombat)
            {
                return state.IsInCombat && !state.Animator.GetBool("IsDamaged");
            }
            else
            {
                return !state.IsInCombat && !state.Animator.GetBool("IsDamaged");
            }
        }
    }
}

