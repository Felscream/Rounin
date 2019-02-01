using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Condition/IsJumping")]
    public class IsJumping : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.InputVariables.XDown && state.IsGrounded;
        }
    }
}

