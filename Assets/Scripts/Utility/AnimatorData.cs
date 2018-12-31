using UnityEngine;
using System.Collections;

public class AnimatorData
{
    public Transform LeftFoot;
    public Transform RightFoot;

    public AnimatorData(Animator anim)
    {
        LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
    }
}
