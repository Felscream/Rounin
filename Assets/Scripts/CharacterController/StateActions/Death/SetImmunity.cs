using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/SetImmunity")]
    public class SetImmunity : StateActions
    {
        public bool Value;

        public override void Execute(StateManager states)
        {
            states.IsImmune = Value;
            states.PlayerVariables.PlayerCollision.enabled = !Value;
            states.PlayerVariables.HurtBox.enabled = !Value;
        }
    }
}

