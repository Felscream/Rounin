using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/RotateTowardTarget")]
    public class RotateTowardTarget : StateActions
    {
        public override void Execute(StateManager states)
        {
            if(states.Target != null)
            {
                Vector3 dir = (states.Target.position - states.mTransform.position).normalized;
                dir.y = 0f;
                states.mTransform.rotation = Quaternion.LookRotation(dir);
            }
        }
    }
}

