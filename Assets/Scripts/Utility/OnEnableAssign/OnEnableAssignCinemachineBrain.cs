using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class OnEnableAssignCinemachineBrain : MonoBehaviour
    {
        public CinemachineBrainVariable TargetVariable;

        private void OnEnable()
        {
            TargetVariable.value = GetComponent<Cinemachine.CinemachineBrain>();
            Destroy(this);
        }
    }
}

