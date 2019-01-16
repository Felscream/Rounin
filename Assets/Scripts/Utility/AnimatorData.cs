using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimatorData
    {
        public Transform LeftFoot;
        public Transform RightFoot;
        public Transform RightHand;
        public Transform LeftHand;
        public Animator Animator;

        public AnimatorData(Animator anim)
        {
            Animator = anim;
            LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
            RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
            RightHand = anim.GetBoneTransform(HumanBodyBones.RightHand);
            LeftHand = anim.GetBoneTransform(HumanBodyBones.LeftHand);

            AnimatorHook aHook = anim.GetComponent<AnimatorHook>();
            if (aHook == null)
                aHook = aHook.gameObject.AddComponent<AnimatorHook>();
            aHook.Data = this;
        }
    }
}

