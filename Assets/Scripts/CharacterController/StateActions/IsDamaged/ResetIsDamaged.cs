using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Damaged/ResetDamaged")]
    public class ResetIsDamaged : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.IsDamaged = false;
        }
    }
}

