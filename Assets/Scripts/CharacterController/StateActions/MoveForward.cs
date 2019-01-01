using System.Collections;
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
        public float MovementFloor = 0.1f;
        public float RunThreshold = 0.6f;
        public float RaycastLength = 2f;
        public float StepHeight = 0.3f;
        public float SideAngle = 50f;
        public LayerMask EnvironmentLayer;
        public TransformVariable CameraTransform;
        
        public override void Execute(StateManager states)
        {

            Vector3 origin = states.mTransform.position + Vector3.up * StepHeight;
            Vector2 inputsValues = new Vector2(states.MovementVariables.Horizontal, states.MovementVariables.Vertical);
            float speed = inputsValues.magnitude > RunThreshold ? MovementSpeed : WalkSpeed;
            if (CameraTransform != null)
            {
                Color dbgColor = Color.blue;
                
                Vector3 tarDirection = CameraTransform.value.forward * inputsValues.y;
                tarDirection += CameraTransform.value.right * inputsValues.x;
                tarDirection.Normalize();
                tarDirection.y = 0;

                if (Physics.Raycast(origin, tarDirection, RaycastLength, EnvironmentLayer))
                {
                    states.CanMoveForward = false;
                    dbgColor = Color.red;
                }
                else
                {
                    states.CanMoveForward = true;
                }

                Debug.DrawLine(origin, origin + tarDirection * RaycastLength, dbgColor);
            }
            
            if (states.CanMoveForward && states.MovementVariables.MoveAmount > MovementFloor)
            {
                states.Rigidbody.drag = 0f;
                Vector3 tarVelocity = states.mTransform.forward * states.MovementVariables.MoveAmount * speed;
                tarVelocity.y = states.Rigidbody.velocity.y;
                states.Rigidbody.velocity = tarVelocity;
            }
            else
            {
                states.Rigidbody.drag = 4f;
                states.MovementVariables.MoveAmount = 0f;
            }

            CheckObstaclesOnSides(states, origin);
        }

        private void CheckObstaclesOnSides(StateManager state, Vector3 origin)
        {
            Vector3 dir = Quaternion.AngleAxis(SideAngle, Vector3.up) * state.mTransform.forward;
            
            if(Physics.Raycast(origin, dir, RaycastLength, EnvironmentLayer))
            {
                Debug.DrawLine(origin, origin + dir, Color.green);
                state.IsBetweenObstacles = true;
            }
            else
            {
                dir = Quaternion.AngleAxis(-SideAngle, Vector3.up) * state.mTransform.forward;
                if (Physics.Raycast(origin, dir, RaycastLength, EnvironmentLayer))
                {
                    Debug.DrawLine(origin, origin + dir, Color.green);
                    state.IsBetweenObstacles = true;
                }
                else
                {
                    state.IsBetweenObstacles = false;
                }
            }
        }
    }
}

