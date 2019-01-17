using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

[CreateAssetMenu(menuName = "Actions/State Actions/Running/Camera")]
public class RunningCamera : StateActions
{
    public bool Value;

    public override void Execute(StateManager states)
    {
        if (Value)
        {
            states.PlayerVariables.CinemachineCamera.running.Priority = 11;
            states.PlayerVariables.CinemachineCamera.value.Priority = 10;
        }
        else
        {
            states.PlayerVariables.CinemachineCamera.running.Priority = 10;
            states.PlayerVariables.CinemachineCamera.value.Priority = 11;
        }
    }
}
