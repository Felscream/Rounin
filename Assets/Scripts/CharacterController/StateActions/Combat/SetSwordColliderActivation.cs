using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/SetSwordColliderActivation")]
    public class SetSwordColliderActivation : StateActions
    {
        public bool Value;

        public override void Execute(StateManager states)
        {
            states.Sword.SetSwordColliderActivation(Value);
        }
    }
}

