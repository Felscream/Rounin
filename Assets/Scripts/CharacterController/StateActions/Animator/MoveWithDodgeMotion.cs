using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Combat/MoveWithDodgeMotion")]
    public class MoveWithDodgeMotion : StateActions
    {
        public float Dash = 10f;
        public float BackDodge = 10f;
        public float LeftDodge = 10f;
        public float RightDodge = 10f;

        public override void Execute(StateManager states)
        {
            float multiplier = BackDodge;
            float x = states.Animator.GetFloat(states.Hashes.DodgeX);
            float y = states.Animator.GetFloat(states.Hashes.DodgeY);

            if(x != 0)
            {
                if(x > 0)
                {
                    multiplier = RightDodge;
                }
                else
                {
                    multiplier = LeftDodge;
                }
            }
            else if( y != 0){
                if (y > 0)
                {
                    multiplier = Dash;
                }
                else
                {
                    multiplier = BackDodge;
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

