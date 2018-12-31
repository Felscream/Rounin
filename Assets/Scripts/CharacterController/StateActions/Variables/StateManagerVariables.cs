using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/StateManager")]
    public class StateManagerVariables : ScriptableObject
    {
        public StateManager Value;

        public void Set(StateManager s)
        {
            Value = s;
        }
    }
}

