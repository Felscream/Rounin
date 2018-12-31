using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Monitor Feet")]
    public class MonitorFeet : StateActions
    {
        public override void Execute(StateManager states)
        {
            Vector3 right_relative = states.mTransform.InverseTransformPoint(states.AnimData.RightFoot.position);
            Vector3 left_relative = states.mTransform.InverseTransformPoint(states.AnimData.LeftFoot.position);

            bool leftForward = false;
            if (left_relative.z > right_relative.z)
                leftForward = true;

            states.Animator.SetBool(states.Hashes.LeftFootForsward, leftForward);
        }
    }
}

