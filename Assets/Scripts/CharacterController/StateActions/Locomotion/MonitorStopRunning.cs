﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

[CreateAssetMenu(menuName = "Conditions/Locomotion/MonitorStopRunning")]
public class MonitorStopRunning : Condition
{
    public override bool CheckCondition(StateManager states)
    {
        if (!states.InputVariables.A 
            || states.MovementVariables.MoveAmount <= Constants.MovementThreshold)
        {
            return true;
        }
        return false;
    }
}
