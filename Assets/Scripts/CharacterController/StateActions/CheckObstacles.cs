using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/CheckObstacles")]
    public class CheckObstacles : StateActions
    {
        public bool AllowMovement;
        public float RaycastLength = 2f;
        public float StepHeight = 0.3f;
        public float SideAngle = 50f;
        public LayerMask EnvironmentLayer;

        public override void Execute(StateManager states)
        {
            if (!AllowMovement)
            {
                CheckForObstacles(states);
            }
        }

        private void CheckObstaclesInFront(StateManager state, Vector3 origin)
        {
            Color dbgColor = Color.blue;

            Vector3 tarDirection = state.MovementVariables.MoveDirection;

            if (Physics.Raycast(origin, tarDirection, RaycastLength, EnvironmentLayer))
            {
                state.CanMoveForward = false;
                dbgColor = Color.red;
            }
            else
            {
                state.CanMoveForward = true;
            }

            Debug.DrawLine(origin, origin + tarDirection * RaycastLength, dbgColor);
        }

        private void CheckObstaclesOnSides(StateManager state, Vector3 origin)
        {
            Vector3 dir = Quaternion.AngleAxis(SideAngle, Vector3.up) * state.mTransform.forward;

            if (Physics.Raycast(origin, dir, RaycastLength, EnvironmentLayer))
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

        private void CheckForObstacles(StateManager state)
        {
            Vector3 origin = state.mTransform.position + Vector3.up * StepHeight;
            if (state.PlayerVariables.CameraTransform != null)
            {
                CheckObstaclesInFront(state, origin);
            }
            CheckObstaclesOnSides(state, origin);
        }
    }
}

