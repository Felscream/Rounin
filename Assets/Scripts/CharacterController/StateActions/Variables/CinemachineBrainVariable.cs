using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/CinemachineBrainVariable")]
    public class CinemachineBrainVariable : ScriptableObject
    {
        public Cinemachine.CinemachineBrain value;

        public void Set(Cinemachine.CinemachineBrain v)
        {
            value = v;
        }
    }
}

