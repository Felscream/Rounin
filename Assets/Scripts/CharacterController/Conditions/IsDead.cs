using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/IsDead")]
    public class IsDead : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.HealthManager.BaseHealth <= 0f;
        }
    }
}

