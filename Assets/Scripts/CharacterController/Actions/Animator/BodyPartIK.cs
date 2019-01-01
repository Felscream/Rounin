using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/Animator Action/FootIk")]
    public class BodyPartIK : AnimatorAction
    {
        public AvatarIKGoal IKGoal;
        public string TargetCurve;
        public float OriginOffset = 0.2f;
        public float FeetOffset = 0.1f;

        public override void Execute(AnimatorData data)
        {
            Transform originTransform = IKGoal == AvatarIKGoal.LeftFoot ? data.LeftFoot : data.RightFoot;
            float weight = data.Animator.GetFloat(TargetCurve);
            RaycastHit hit;

            Vector3 origin = originTransform.position;
            origin.y += OriginOffset;

            Vector3 dir = -Vector3.up;

            Vector3 tarPosition = origin;
            if (Physics.Raycast(origin, dir, out hit, 1f, Layers.IgnoreLayersIsGrounded))
            {
                tarPosition = hit.point + Vector3.up * FeetOffset;
            }
            data.Animator.SetIKPositionWeight(IKGoal, weight);
            data.Animator.SetIKPosition(IKGoal, tarPosition);
        }
    }
}

