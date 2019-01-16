using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/FocusTarget")]
    public class FocusTarget : StateActions
    {
        public LayerMask TargetLayer;
        public LayerMask ObstaclesLayer;
        public float RaycastYOffset = 1f;

        [Range(-1f, 1f)] public float FocusAngleRange = -0.3f;
        public float UpdatePeriod = 1f;

        public override void Execute(StateManager states)
        {
            if (states.Target == null )
            {
                FindTarget(states);
            }
            else if(states.Target != null)
            {
                if (Vector3.Distance(states.PlayerVariables.CameraTransform.transform.position, states.Target.position) > Constants.FocusLossRange 
                    || AreObstaclesOnTheWay(states, states.Target))
                {
                    NullTarget(states);
                }
            } 
            
        }

        private void NullTarget(StateManager s)
        {
            s.Target = null;
        }

        private void AssignTarget(StateManager states, Transform t)
        {
            states.Target = t;
        }

        private void ComputeAngle(StateManager s, Transform t)
        {
            Vector3 dir = (s.PlayerVariables.CameraTransform.position - t.position).normalized;
            float angle = Vector3.Dot(s.PlayerVariables.CameraTransform.forward, dir);
            if (angle < FocusAngleRange)
            {
                AssignTarget(s, t);
            }
            else
            {
                NullTarget(s);
            }
        }

        private void FindClosestTarget(StateManager s, Collider[] targets)
        {
            Transform camera = s.PlayerVariables.CameraTransform;
            Transform closest = null;
            float minDist = float.MaxValue;
            for (int i = 0; i < targets.Length; ++i)
            {
                if(targets[i].transform != s.mTransform)
                {
                    float dist = Vector3.Distance(targets[i].transform.position, camera.position);
                    if (dist < minDist)
                    {
                        minDist = dist;
                        closest = targets[i].transform;
                    }
                }
            }

            if (closest != null && !AreObstaclesOnTheWay(s, closest))
            {
                ComputeAngle(s, closest);
            }
            else
            {
                NullTarget(s);
            }
        }

        private void FindTarget(StateManager states)
        {
            Transform camera = states.PlayerVariables.CameraTransform;
            Collider[] possibleTargets = Physics.OverlapSphere(camera.position, Constants.FocusRange, TargetLayer);
            if (possibleTargets.Length > 0)
            {
                FindClosestTarget(states, possibleTargets);
            }
            else
            {
                NullTarget(states);
            }
        }

        private bool AreObstaclesOnTheWay(StateManager s, Transform target)
        {
            bool result = true;

            if(target != null)
            {
                Vector3 origin = s.PlayerVariables.CombatCameraTransform.position;
                Vector3 dir = (target.position + Vector3.up * RaycastYOffset) - origin;
                Debug.DrawRay(origin, dir, Color.green);
                RaycastHit hit;
                if (Physics.Raycast(origin, dir.normalized, out hit, Constants.FocusLossRange, ObstaclesLayer | TargetLayer))
                {
                    if(1 << hit.collider.gameObject.layer == TargetLayer)
                        result = false;
                }
            }

            return result;
        }
    }
}

