using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimHashes
    {
        public readonly int Speed = Animator.StringToHash("Speed");
        public readonly int LeftFootForsward = Animator.StringToHash("LeftFootForward");
        public readonly int StandingIdle = Animator.StringToHash("StandingIdle");
        public readonly int IdleRand = Animator.StringToHash("IdleRand");
        public readonly int MoveX = Animator.StringToHash("MoveX");
        public readonly int MoveY = Animator.StringToHash("MoveY");
        public readonly int JumpForward = Animator.StringToHash("JumpForward");
        public readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        public readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        public readonly int LandLowVelocity = Animator.StringToHash("FallLandLowVelocity");
        public readonly int FallLandHard = Animator.StringToHash("FallLandHard");
        public readonly int FallAndRoll = Animator.StringToHash("FallAndRoll");
        public readonly int IsInteracting = Animator.StringToHash("IsInteracting");
        public readonly int VaultWalk = Animator.StringToHash("Vault");

        public readonly int CombatMode = Animator.StringToHash("CombatMode");
        public readonly int CombatIdle = Animator.StringToHash("Combat.Idle");
        public readonly int EquipWeapon = Animator.StringToHash("EquipWeapon.Equip");
        public readonly int UnequipWeapon = Animator.StringToHash("EquipWeapon.Unequip");

        public readonly int Dodge = Animator.StringToHash("Combat.Dodge");
        public readonly int IsDodging = Animator.StringToHash("IsDodging");
        public readonly int DodgeX = Animator.StringToHash("DodgeX");
        public readonly int DodgeY = Animator.StringToHash("DodgeY");

        public readonly int IsRunning = Animator.StringToHash("IsRunning");

        public readonly int RightStance = Animator.StringToHash("GuardStance.RightStance");
        public readonly int GuardY = Animator.StringToHash("GuardY");
        public readonly int GuardOn = Animator.StringToHash("GuardOn");

        public readonly int IsAttackingHeavy = Animator.StringToHash("IsAttackingHeavy");
        public readonly int IsAttackingLight = Animator.StringToHash("IsAttackingLight");
        public readonly int Combo = Animator.StringToHash("Combo");
        public readonly int HeavyLeft = Animator.StringToHash("Combat.Attacks.HeavyLeft");
        public readonly int HeavyRight = Animator.StringToHash("Combat.Attacks.HeavyRight");
        public readonly int HeavyUp = Animator.StringToHash("Combat.Attacks.HeavyUp");
        
        public readonly int LightLeft = Animator.StringToHash("LightAttacks.LightLeft");
        public readonly int LightRight = Animator.StringToHash("LightAttacks.LightRight");
        public readonly int LightUp = Animator.StringToHash("Combat.Attacks.LightUp");

        public readonly int IsDamaged = Animator.StringToHash("IsDamaged");

        public readonly int ReactionFront = Animator.StringToHash("DamageReaction.HitReaction_IdleFront");
        public readonly int ReactionLeft = Animator.StringToHash("DamageReaction.HitReaction_IdleLeft");
        public readonly int ReactionRight = Animator.StringToHash("DamageReaction.HitReaction_IdleRight");

        public readonly int ReactionLightFront = Animator.StringToHash("DamageReaction.HitReaction_LightFront");
        public readonly int ReactionLightLeft = Animator.StringToHash("DamageReaction.HitReaction_LightLeft");
        public readonly int ReactionLightRight = Animator.StringToHash("DamageReaction.HitReaction_LightRight");
        public readonly int ReactionLightBack = Animator.StringToHash("DamageReaction.HitReaction_LightBack");

        public readonly int ReactionHeavyFront = Animator.StringToHash("DamageReaction.HitReaction_HeavyFront");
        public readonly int ReactionHeavyFrontLeft = Animator.StringToHash("DamageReaction.HitReaction_HeavyFrontLeft");
        public readonly int ReactionHeavyLeft = Animator.StringToHash("DamageReaction.HitReaction_HeavyLeft");

        public readonly int ReactionHeavyFrontRight = Animator.StringToHash("DamageReaction.HitReaction_HeavyFrontRight");
        public readonly int ReactionHeavyRight = Animator.StringToHash("DamageReaction.HitReaction_HeavyRight");
        public readonly int ReactionHeavyBack = Animator.StringToHash("DamageReaction.HitReaction_HeavyBack");
    }
}

