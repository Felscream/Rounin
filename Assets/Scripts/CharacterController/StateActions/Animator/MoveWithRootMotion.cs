using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/MoveWithRootMotion")]
    public class MoveWithRootMotion : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.Animator.transform.localPosition = Vector3.zero;
            states.Rigidbody.drag = 0f;
            Vector3 v = states.Rigidbody.velocity;
            Vector3 tarVelocity = states.Animator.deltaPosition;
            tarVelocity *= 60f;
            tarVelocity.y = v.y;
            states.Rigidbody.velocity = tarVelocity;
        }
    }
}

