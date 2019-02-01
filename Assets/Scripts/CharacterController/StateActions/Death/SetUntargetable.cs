using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/SetUntagetable")]
    public class SetUntargetable : StateActions
    {
        public bool Value;

        public override void Execute(StateManager states)
        {
            states.mTransform.gameObject.layer = Value ? Layers.UntargetableLayer : Layers.HurtBoxLayer;
        }
    }
}

