using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

[CreateAssetMenu(menuName = "Conditions/Running/IsRunning")]
public class IsRunning : Condition
{
    public bool Value;
    public override bool CheckCondition(StateManager state)
    {
        if (Value)
            return state.IsRunning;
        else
            return !state.IsRunning;
    }
}
