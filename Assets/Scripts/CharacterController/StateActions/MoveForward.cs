﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;
namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Movement Forward")]
    public class MoveForward : StateActions
    {
        public float MovementSpeed = 2f;
        public float WalkSpeed = 1.5f;
        
        public override void Execute(StateManager states)
        {
            if (states.CanMoveForward && states.MovementVariables.MoveAmount > Constants.MovementThreshold)
            {
                states.Animator.applyRootMotion = false;
                float speed = states.MovementVariables.MoveAmount > Constants.RunThreshold ? MovementSpeed : WalkSpeed;
                Vector3 tarVelocity = states.mTransform.forward * speed;
                if (!states.IsGrounded)
                {
                    tarVelocity.y = states.Rigidbody.velocity.y;
                }
                else
                {
                    tarVelocity.y = 0f;
                }
                states.Rigidbody.drag = 0f;
                states.Rigidbody.velocity = tarVelocity;
                
            }
            else
            {
                states.Rigidbody.drag = 1000f;
            }
        }
    }
}

