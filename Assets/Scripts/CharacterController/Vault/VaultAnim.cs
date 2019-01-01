using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Vault/VaultAnimData")]
    public class VaultAnim : ScriptableObject
    {
        public float DistanceFromGround = 0.2f;

        public AnimationClip VaultAnimation;
        public AnimationCurve SpeedCurve;
        public AnimationCurve ElevationCurve;
        public string AnimName;
    }
}

