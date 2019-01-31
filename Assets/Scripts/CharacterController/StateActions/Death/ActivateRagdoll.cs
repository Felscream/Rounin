using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(fileName = "ActivateRagdoll", menuName = "Actions/State Actions/Death/ActivateRagdoll")]
    public class ActivateRagdoll : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.RagdollController.ActivateRagDoll(true);
        }
    }
}

