using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/Action Batch")]
    public class ActionBatch : Action
    {
        public Action[] Actions;
        public override void Execute()
        {
            for(int i = 0; i < Actions.Length; ++i)
            {
                Actions[i].Execute();
            }
        }
    }
}

