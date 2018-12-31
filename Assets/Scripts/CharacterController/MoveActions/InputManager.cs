using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/Input Manager")]
    public class InputManager : Action
    {
        public FloatVariable Horizontal;
        public FloatVariable Vertical;

        public StateManagerVariables PlayerSates;
        public ActionBatch InputUpdateBatch;

        public override void Execute()
        {
            InputUpdateBatch.Execute();

            if(PlayerSates.Value != null)
            {
                PlayerSates.Value.MovementVariables.Horizontal = Horizontal.value;
                PlayerSates.Value.MovementVariables.Vertical = Vertical.value;

                PlayerSates.Value.MovementVariables.MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal.value) + Mathf.Abs(Vertical.value));
            }
        }
    }
}

