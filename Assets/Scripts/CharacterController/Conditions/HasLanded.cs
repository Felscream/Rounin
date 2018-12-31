using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/HasLanded")]
    public class HasLanded : Condition
    {

        public override bool CheckCondition(StateManager state)
        {
            if (Time.realtimeSinceStartup - state.TimeSinceFall > 0.2f)
            {
                return state.IsGrounded;
            }
            else
            {
                return false;
            }
        }
    }
}

