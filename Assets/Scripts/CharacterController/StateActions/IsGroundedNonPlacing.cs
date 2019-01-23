using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/IsGroundedNonPlacing")]
    public class IsGroundedNonPlacing : StateActions
    {

        public float GroundedDistance = .8f;
        public float InAirDistance = .85f;
        public override void Execute(StateManager states)
        {
            Vector3 origin = states.mTransform.position;
            origin.y += .7f;
            float d = states.IsGrounded ? GroundedDistance : InAirDistance;

            RaycastHit hit;
            
            if (Physics.SphereCast(origin, 0.25f, -Vector3.up, out hit, d, Layers.GroundLayers))
            {
                states.IsGrounded = true;
            }
            else
            {
                states.IsGrounded = false;
            }
        }
    }
}


