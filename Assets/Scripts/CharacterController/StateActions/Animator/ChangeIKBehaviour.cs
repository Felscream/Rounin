using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/ChangeIKBehaviour")]
    public class ChangeIKBehaviour : StateActions
    {
        public bool UpdateEmptyValues = true;
        public BodyPartIK[] IKActions;

        public override void Execute(StateManager states)
        {
            for(int i = 0; i < IKActions.Length; ++i)
            {
                if(IKActions[i] != null || UpdateEmptyValues)
                    states.AnimatorHook.ChangeIKAction(IKActions[i].IKGoal, IKActions[i]);
            }
        }
    }
}

