using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

[CreateAssetMenu(menuName = "Actions/State Actions/Locomotion/MonitorRunning")]
public class MonitorRunning : StateActions
{
    public override void Execute(StateManager states)
    {

        if (states.InputVariables.A && states.MovementVariables.MoveAmount > Constants.MovementThreshold && states.CanMoveForward)
        {
            states.IsRunning = true;
        }
        else
        {
            states.IsRunning = false;
        }
    }
}
