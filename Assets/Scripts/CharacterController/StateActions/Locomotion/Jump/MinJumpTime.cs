using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Jump/MinJumpTime")]
    public class MinJumpTime : StateActions
    {
        public float GroundedDistance = 1.4f;
        public float InAirDistance = 1f;
        public float MinAirTime = 0.5f;

        public override void Execute(StateManager states)
        {
            float diffTime = Time.realtimeSinceStartup - states.TimeSinceJump;
            bool res = false;
            if(diffTime > MinAirTime)
            {
                Vector3 origin = states.mTransform.position;
                origin.y += .7f;
                float d = states.IsGrounded ? GroundedDistance : InAirDistance;

                RaycastHit hit;
                Debug.DrawRay(origin, -Vector3.up * d);
                if (Physics.SphereCast(origin, 0.25f, -Vector3.up, out hit, d, Layers.GroundLayers))
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            states.IsGrounded = res;
        }
    }
}

