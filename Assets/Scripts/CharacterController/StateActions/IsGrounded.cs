using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/IsGrounded")]
    public class IsGrounded : StateActions
    {
        public LayerMask IgnoreLayer;
        public override void Execute(StateManager states)
        {
            Vector3 origin = states.mTransform.position;
            origin.y += .7f;
            float d = 0.9f;

            RaycastHit hit;
            if(Physics.Raycast(origin, -Vector3.up, out hit, d, ~IgnoreLayer))
            {
                states.IsGrounded = true;
            }
            else
            {
                states.IsGrounded = false;
                Debug.Log("falling");
                states.TimeSinceFall = Time.realtimeSinceStartup;
            }

            states.Animator.SetBool(states.Hashes.IsGrounded, states.IsGrounded);
        }
    }
}

