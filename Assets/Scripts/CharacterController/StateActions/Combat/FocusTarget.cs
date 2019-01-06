using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/FocusTarget")]
    public class FocusTarget : StateActions
    {
        public LayerMask TargetLayer;

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
                if (Vector3.Distance(states.PlayerVariables.CameraTransform.value.transform.position, states.Target.position) > Constants.FocusLossRange)
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
            Vector3 dir = (s.PlayerVariables.CameraTransform.value.position - t.position).normalized;
            float angle = Vector3.Dot(s.PlayerVariables.CameraTransform.value.forward, dir);
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
            Transform camera = s.PlayerVariables.CameraTransform.value; ;
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

            if (closest != null)
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
            Transform camera = states.PlayerVariables.CameraTransform.value;
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
    }
}

