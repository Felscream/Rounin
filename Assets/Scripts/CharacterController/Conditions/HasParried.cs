using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/Combat/HasParried")]
    public class HasParried : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.GuardVariables.ParryData.HasParried;
        }
    }
}

