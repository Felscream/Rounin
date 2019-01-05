using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    
    public class InputManager : Action
    {
        public FloatVariable Horizontal;
        public FloatVariable Vertical;

        public StateManagerVariables PlayerStates;
        public ActionBatch InputUpdateBatch;

        public override void Execute()
        {
            InputUpdateBatch.Execute();

            if(PlayerStates != null && PlayerStates.Value != null)
            {
                PlayerStates.Value.MovementVariables.Horizontal = Horizontal.value;
                PlayerStates.Value.MovementVariables.Vertical = Vertical.value;

                PlayerStates.Value.MovementVariables.MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal.value) + Mathf.Abs(Vertical.value));
            }
        }
    }
}

