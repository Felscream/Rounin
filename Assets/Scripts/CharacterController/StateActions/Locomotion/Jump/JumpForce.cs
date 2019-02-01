using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Jump/JumpForce")]
    public class JumpForce : StateActions
    {
        public float MinForwardForce = 6f;
        public float UpForce = 10f;
        public override void Execute(StateManager states)
        {
            Vector3 tarVelocity = states.Rigidbody.velocity;
            tarVelocity += Vector3.up * UpForce /*+ states.mTransform.forward * MinForwardForce*/;
            states.Rigidbody.drag = 0f;
            states.Rigidbody.AddForce(tarVelocity, ForceMode.VelocityChange);
        }
    }
}

