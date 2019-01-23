using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/MoveWithAttackMotion")]
    public class MoveWithAttackMotion : StateActions
    {
        public float HeavyLeft = 1f;
        public float HeavyRight = 1f;
        public float HeavyUp = 30f;
        public float LightUp = 50f;

        public override void Execute(StateManager states)
        {
            float multiplier = LightUp;
            if (states.PlayerVariables.IsAttackingHeavy)
            {
                Vector2 dir = states.GuardVariables.GuardDirection;

                if (dir.x == 1f)
                {
                    multiplier = states.PlayerVariables.IsAttackingHeavy ? HeavyRight : 1f;
                }
                else if (dir.x == -1f)
                {
                    multiplier = states.PlayerVariables.IsAttackingHeavy ? HeavyLeft : 1f;
                }
                else if (dir.y == 1f)
                {
                    multiplier = states.PlayerVariables.IsAttackingHeavy ? HeavyUp : 1f;
                }
            }

            states.Animator.transform.localPosition = Vector3.zero;
            states.Animator.transform.localRotation = Quaternion.identity;
            states.Rigidbody.drag = 0f;
            Vector3 v = states.Rigidbody.velocity;
            Vector3 tarVelocity = states.Animator.deltaPosition;
            tarVelocity *= multiplier;
            tarVelocity.y = v.y;
            states.Rigidbody.velocity = tarVelocity;
        }
    }
}

