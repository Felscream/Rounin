using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/ColldierStatus")]
    public class ColliderStatus : StateActions
    {
        public bool status;
        public override void Execute(StateManager states)
        {
            states.Collider.enabled = status;
        }
    }
}

