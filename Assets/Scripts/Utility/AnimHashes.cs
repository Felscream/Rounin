using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimHashes
    {
        public int Speed = Animator.StringToHash("Speed");
        public int LeftFootForsward = Animator.StringToHash("LeftFootForward");
        public int StandingIdle = Animator.StringToHash("StandingIdle");
        public int JumpForward = Animator.StringToHash("JumpForward");
        public int JumpIdle = Animator.StringToHash("JumpIdle");
        public int IsGrounded = Animator.StringToHash("IsGrounded");
        public int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        public int LandLowVelocity = Animator.StringToHash("FallLandLowVelocity");
        public int FallLandHard = Animator.StringToHash("FallLandHard");
        public int FallAndRoll = Animator.StringToHash("FallAndRoll");
        
    }
}

