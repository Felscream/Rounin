using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/CinemachineFreeLookCameraVariable")]
    public class CinemachineFreeLookCameraVariable : ScriptableObject
    {
        public CinemachineFreeLook value;
        public CinemachineVirtualCamera combat;
        public CinemachineConfiner confiner;

        public void Set(CinemachineFreeLook v, CinemachineConfiner cc)
        {
            value = v;
            confiner = cc;
        }
    }
}

