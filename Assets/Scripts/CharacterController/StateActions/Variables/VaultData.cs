using UnityEngine;
using System.Collections;

namespace SA
{
    [System.Serializable]
    public class VaultData
    {
        public Vector3 StartPosition;
        public Vector3 EndPosition;
        public float VaultSpeed = 1.1f;
        public float vaultT;
        public bool isInit;
        public float AnimLength;
    }
}

