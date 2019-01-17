using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

[CreateAssetMenu(menuName = "Actions/State Actions/Running/SetRunning")]
public class RunningAnimation : StateActions
{
    public bool Value;
    public override void Execute(StateManager states)
    {
        states.Animator.SetBool(states.Hashes.IsRunning, Value);
    }
}
