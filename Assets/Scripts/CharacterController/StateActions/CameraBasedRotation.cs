using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Camera Based Rotation")]
    public class CameraBasedRotation : StateActions
    {
        public TransformVariable CameraTransform;
        public float speed = 1f;

        public override void Execute(StateManager states)
        {
            if (CameraTransform == null)
                return;

            float h = states.MovementVariables.Horizontal;
            float v = states.MovementVariables.Vertical;

            Vector3 tarDirection = CameraTransform.value.forward * v;
            tarDirection += CameraTransform.value.right * h;
            tarDirection.Normalize();
            tarDirection.y = 0;

            if(tarDirection == Vector3.zero)
            {
                tarDirection = states.mTransform.forward;
            }

            Quaternion q = Quaternion.LookRotation(tarDirection);
            Quaternion targetRotation = Quaternion.Slerp(states.mTransform.rotation, q, states.delta * states.MovementVariables.MoveAmount * speed);

            states.mTransform.rotation = targetRotation;
        }
    }
}

