using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/HandleFallVelocity")]
    public class HandleFallVelocity : StateActions
    {
        public float TerminalVelocity = 10f;
        public float FallMultiplier = 2.5f;

        public override void Execute(StateManager states)
        {
            states.Rigidbody.drag = 0f;
            Vector3 curVelocity = states.Rigidbody.velocity;
            curVelocity += Vector3.up * Physics.gravity.y * (FallMultiplier - 1) * states.delta;
            curVelocity = Vector3.ClampMagnitude(curVelocity, TerminalVelocity);
            
            states.Rigidbody.velocity = curVelocity;
        }
    }
}

