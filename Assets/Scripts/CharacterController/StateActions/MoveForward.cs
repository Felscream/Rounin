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
        public float RaycastLength = 2f;
        public float StepHeight = 0.3f;
        public float SideAngle = 50f;
        public LayerMask EnvironmentLayer;
        public TransformVariable CameraTransform;
        
        public override void Execute(StateManager states)
        {
            Color dbgColor = Color.blue;
            Vector3 origin = states.mTransform.position + Vector3.up * StepHeight;

            if(CameraTransform != null)
            {
                float h = states.MovementVariables.Horizontal;
                float v = states.MovementVariables.Vertical;

                Vector3 tarDirection = CameraTransform.value.forward * v;
                tarDirection += CameraTransform.value.right * h;
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
            }
            

            if(states.MovementVariables.MoveAmount > 0.1f && states.CanMoveForward)
            {
                states.Rigidbody.drag = 0f;
                
            }
            else
            {
                states.Rigidbody.drag = 4f;
            }
            
            if (states.CanMoveForward)
            {
                Vector3 tarVelocity = states.mTransform.forward * states.MovementVariables.MoveAmount * MovementSpeed;
                tarVelocity.y = states.Rigidbody.velocity.y;
                states.Rigidbody.velocity = tarVelocity;
            }
            else
            {
                states.MovementVariables.MoveAmount = 0f;
            }

            Debug.DrawLine(origin, origin + states.mTransform.forward * RaycastLength, dbgColor);

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

