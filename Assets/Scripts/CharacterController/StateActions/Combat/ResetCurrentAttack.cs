using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/ResetAttack")]
    public class ResetCurrentAttack : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.CurrentAttack = new ComboAttack();
        }
    }
}

