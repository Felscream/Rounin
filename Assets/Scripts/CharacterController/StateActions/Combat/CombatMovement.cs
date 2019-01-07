using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/CombatMovement")]
    public class CombatMovement : StateActions
    {
        public float MovementSpeed = 2f;
        public override void Execute(StateManager states)
        {
            if (states.MovementVariables.MoveAmount > Constants.MovementThreshold)
            {
                states.Rigidbody.drag = 0f;
                Transform camera = states.Target != null ? states.PlayerVariables.CombatCameraTransform.value : states.PlayerVariables.CameraTransform.value;
                Vector3 camForward = camera.forward.normalized;
                camForward.y = 0f;
                Vector3 camRight = camera.right.normalized;
                camRight.y = 0f;

                Vector2 input = new Vector2(states.MovementVariables.Horizontal, states.MovementVariables.Vertical).normalized;
                Vector3 tarVelocity = (camForward * input.y + camRight * input.x).normalized;
                states.Rigidbody.velocity = tarVelocity;
            }
            else
            {
                states.Rigidbody.drag = 8f;
            }
        }
    }
}

