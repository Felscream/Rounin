using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/IsFalling")]
    public class IsFalling : Condition
    {

        public override bool CheckCondition(StateManager state)
        {
            return !state.IsGrounded;
        }
    }
}
