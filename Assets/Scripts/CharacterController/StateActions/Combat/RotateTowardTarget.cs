using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/RotateTowardTarget")]
    public class RotateTowardTarget : StateActions
    {
        public float RotationSpeed = 2f;
        public override void Execute(StateManager states)
        {
            if (states.Target != null)
            {
                float step = RotationSpeed * states.delta;
                Vector3 dirToTarget = states.Target.position - states.mTransform.position;
                dirToTarget.y = 0f;

                Vector3 newDir = Vector3.RotateTowards(states.mTransform.forward, dirToTarget, step, 0f);
                Debug.DrawRay(states.mTransform.position, newDir, Color.red);
                states.mTransform.rotation = Quaternion.LookRotation(newDir);
            }
        }
    }
}

