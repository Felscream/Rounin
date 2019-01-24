using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/IsDamaged")]
    public class IsDamaged : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.IsDamaged;
        }
    }
}

