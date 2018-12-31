using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Movement Forward")]
    public class MoveForward : StateActions
    {
        public float MovementSpeed = 2f;


        public override void Execute(StateManager states)
        {
            if(states.MovementVariables.MoveAmount > 0.1f)
            {
                states.Rigidbody.drag = 0f;
            }
            else
            {
                states.Rigidbody.drag = 4f;
            }

            Vector3 tarVelocity = states.mTransform.forward * states.MovementVariables.MoveAmount * MovementSpeed;
            tarVelocity.y = states.Rigidbody.velocity.y;
            states.Rigidbody.velocity = tarVelocity;
        }
    }
}

