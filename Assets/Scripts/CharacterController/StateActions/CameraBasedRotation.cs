using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Camera Based Rotation")]
    public class CameraBasedRotation : StateActions
    {
        public float speed = 1f;
        public bool running = false;
        public override void Execute(StateManager states)
        {
            if (states.PlayerVariables.CameraTransform == null)
                return;

            float h = states.MovementVariables.Horizontal;
            float v = states.MovementVariables.Vertical;

            Transform camera = !running ? states.PlayerVariables.CameraTransform : states.mTransform;
            Vector3 tarDirection = camera.forward * v;
            tarDirection += camera.right * h;
            tarDirection.Normalize();
            tarDirection.y = 0;

            if(tarDirection == Vector3.zero)
            {
                tarDirection = states.mTransform.forward;
            }

            states.MovementVariables.MoveDirection = tarDirection;
            Quaternion q = Quaternion.LookRotation(tarDirection);
            Quaternion targetRotation = Quaternion.Slerp(states.mTransform.rotation, q, states.delta * states.MovementVariables.MoveAmount * speed);

            states.mTransform.rotation = targetRotation;
        }
    }
}

