using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Jump/AirControl")]
    public class AirControl : StateActions
    {
        public float AirControlPercentage = 0.3f;
        public override void Execute(StateManager states)
        {
            if(states.MovementVariables.MoveAmount > Constants.MovementThreshold)
            {
                Vector3 tarVelocity = states.Rigidbody.velocity;
                tarVelocity.y = 0f;
                tarVelocity *= (1 - AirControlPercentage);
                Vector3 airControl = states.mTransform.forward * Constants.MaxAirXZMagnitude * AirControlPercentage;

                tarVelocity += airControl;

                Vector3.ClampMagnitude(tarVelocity, Constants.MaxAirXZMagnitude);

                tarVelocity.y = states.Rigidbody.velocity.y;
                states.Rigidbody.velocity = tarVelocity;
            }
        }
    }
}

