using UnityEngine;
using System.Collections;

namespace SA
{

    [CreateAssetMenu(menuName = "Conditions/MonitorIfVaultingIsFalse")]
    public class MonitorIfVaultingIsFalse : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return !state.IsVaulting;
        }
    }
}

