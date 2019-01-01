using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimatorData
    {
        public Transform LeftFoot;
        public Transform RightFoot;
        public Animator Animator;

        public AnimatorData(Animator anim)
        {
            Animator = anim;
            LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
            RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

            AnimatorHook aHook = anim.GetComponent<AnimatorHook>();
            if (aHook == null)
                aHook = aHook.gameObject.AddComponent<AnimatorHook>();
            aHook.Data = this;
        }
    }
}

