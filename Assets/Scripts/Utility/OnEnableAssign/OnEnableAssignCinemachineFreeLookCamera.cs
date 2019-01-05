using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(Cinemachine.CinemachineFreeLook))]
    public class OnEnableAssignCinemachineFreeLookCamera : MonoBehaviour
    {
        public CinemachineFreeLookCameraVariable TargetVariable;

        private void OnEnable()
        {
            TargetVariable.value = GetComponent<Cinemachine.CinemachineFreeLook>();
        }
    }
}

