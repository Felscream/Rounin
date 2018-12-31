using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/HandleJumpVelocity")]
    public class HandleJumpVelocity : StateActions
    {
        public float JumpSpeed = 2f;
        public float IdleJumpSpeed = 1.5f;

        public override void Execute(StateManager states)
        {
            states.Rigidbody.drag = 0f;
            Vector3 curVelocity = states.Rigidbody.velocity;

            if(states.MovementVariables.MoveAmount < 0.1f)
            {
                states.Animator.CrossFade(states.Hashes.JumpIdle, 0.2f);
                curVelocity += Vector3.up * IdleJumpSpeed;
            }
            else
            {
                states.Animator.CrossFade(states.Hashes.JumpForward, 0.2f);
                curVelocity += Vector3.up * JumpSpeed;
            }
            states.Rigidbody.velocity = curVelocity;
        }
    }
}

