using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/IsGrounded")]
    public class IsGrounded : StateActions
    {

        public float GroundedDistance = 1.4f;
        public float InAirDistance = 1f;
        public override void Execute(StateManager states)
        {
            Vector3 origin = states.mTransform.position;
            origin.y += .7f;
            float d = states.IsGrounded ? GroundedDistance : InAirDistance;

            RaycastHit hit;
            Debug.DrawRay(origin, -Vector3.up * d);
            if(Physics.SphereCast(origin, 0.25f, -Vector3.up , out hit, d, Layers.IgnoreLayersIsGrounded))
            {
                states.IsGrounded = true;
                Vector3 targetPosition = states.mTransform.position;
                targetPosition.y = hit.point.y;
                states.mTransform.position = targetPosition;
            }
            else
            {
                states.IsGrounded = false;
            }
        }
    }
}

