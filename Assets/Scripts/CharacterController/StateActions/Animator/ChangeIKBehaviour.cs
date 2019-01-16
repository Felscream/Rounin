using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/ChangeIKBehaviour")]
    public class ChangeIKBehaviour : StateActions
    {
        public bool ResetDictionnary = true;
        public BodyPartIK[] IKActions;

        public override void Execute(StateManager states)
        {
            states.AnimatorHook.ChangeIKAction(IKActions, ResetDictionnary);
        }
    }
}

