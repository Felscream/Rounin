using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPoolingTools
{
    public interface IPooledObject
    {
        void OnSpawn();
        void Reset();
    }

    [System.Serializable]
    public struct Pool
    {
        public string Code;
        public GameObject ObjectPrefab;
        public int Size;
    }
}

