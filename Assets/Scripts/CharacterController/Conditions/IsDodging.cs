using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Conditions/Combat/IsDodging")]
    public class IsDodging : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            state.Animator.SetBool(state.Hashes.IsDodging, state.IsDodging);
            return state.IsDodging;
        }
    }
}

