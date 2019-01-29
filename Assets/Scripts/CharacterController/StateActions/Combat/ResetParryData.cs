using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(fileName = "ResetParryData", menuName = "Actions/State Actions/Combat/ResetParryData")]
    public class ResetParryData : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.GuardVariables.ParryData.HasParried = false;
        }
    }
}

