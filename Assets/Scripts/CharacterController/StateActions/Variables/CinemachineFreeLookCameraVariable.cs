using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/CinemachineFreeLookCameraVariable")]
    public class CinemachineFreeLookCameraVariable : ScriptableObject
    {
        public Cinemachine.CinemachineFreeLook value;

        public void Set(Cinemachine.CinemachineFreeLook v)
        {
            value = v;
        }
    }
}

