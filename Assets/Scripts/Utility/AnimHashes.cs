using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimHashes
    {
        public int Speed = Animator.StringToHash("Speed");
        public int LeftFootForsward = Animator.StringToHash("LeftFootForward");
        public int StandingIdle = Animator.StringToHash("StandingIdle");
        public int IdleRand = Animator.StringToHash("IdleRand");
        public int MoveX = Animator.StringToHash("MoveX");
        public int MoveY = Animator.StringToHash("MoveY");
        public int JumpForward = Animator.StringToHash("JumpForward");
        public int IsGrounded = Animator.StringToHash("IsGrounded");
        public int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        public int LandLowVelocity = Animator.StringToHash("FallLandLowVelocity");
        public int FallLandHard = Animator.StringToHash("FallLandHard");
        public int FallAndRoll = Animator.StringToHash("FallAndRoll");
        public int IsInteracting = Animator.StringToHash("IsInteracting");
        public int VaultWalk = Animator.StringToHash("Vault");

        public int CombatMode = Animator.StringToHash("CombatMode");
        public int CombatIdle = Animator.StringToHash("Combat.Idle");
        public int EquipWeapon = Animator.StringToHash("EquipWeapon.Equip");
        public int UnequipWeapon = Animator.StringToHash("EquipWeapon.Unequip");
    }
}

