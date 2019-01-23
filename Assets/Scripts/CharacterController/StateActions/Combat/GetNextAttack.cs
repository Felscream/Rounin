using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/GetNextAttack")]
    public class GetNextAttack : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.CurrentAttack = states.ComboManager.GetNextAttack();
        }
    }
}

