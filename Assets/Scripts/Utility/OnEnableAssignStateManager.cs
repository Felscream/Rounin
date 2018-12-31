using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(StateManager))]
    public class OnEnableAssignStateManager : MonoBehaviour
    {
        public StateManagerVariables TargetVariable;

        private void OnEnable()
        {
            TargetVariable.Value = GetComponent<StateManager>();
            Destroy(this);
        }
    }
}

