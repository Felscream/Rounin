using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Vault/VaultAnimData")]
    public class VaultAnim : ScriptableObject
    {
        public bool IsDown;
        public float min = 0.15f;
        public float max = 0.25f;
        public float Speed = 1f;
        public float AnimOffset = 2f;

        public AnimationClip VaultAnimation;
        public AnimationCurve SpeedCurve;
        public AnimationCurve ElevationCurve;
        public string AnimName;
    }
}

