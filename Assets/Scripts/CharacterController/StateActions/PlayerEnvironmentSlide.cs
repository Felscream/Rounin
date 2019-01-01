using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/PlayerEnvironmentSlide")]
    public class PlayerEnvironmentSlide : StateActions
    {
        public PhysicMaterial SlideMaterial;

        public override void Execute(StateManager states)
        {
            if(SlideMaterial != null)
            {
                if(!states.IsGrounded || states.IsBetweenObstacles)
                {
                    SlideMaterial.dynamicFriction = 0f;
                }
                else
                {
                    SlideMaterial.dynamicFriction = 1f;
                }
            }
            
        }
    }
}

