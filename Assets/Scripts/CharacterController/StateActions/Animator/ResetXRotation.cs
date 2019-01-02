using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/ResetXRotation")]
    public class ResetXRotation : StateActions
    {
        public override void Execute(StateManager states)
        {
            Vector3 euler = states.mTransform.rotation.eulerAngles;
            if(euler.x != 0f)
            {
                euler.x = 0f;
                states.mTransform.rotation = Quaternion.Euler(euler);
            }
            
        }
    }
}

