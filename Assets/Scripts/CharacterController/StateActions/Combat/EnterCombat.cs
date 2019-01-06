using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/EnterCombat")]
    public class EnterCombat : StateActions
    {
        public bool CombatState;

        public override void Execute(StateManager states)
        {
            if (states.IsGrounded)
            {
                states.Animator.SetBool(states.Hashes.IsInteracting, true);
                states.Animator.SetBool(states.Hashes.CombatMode, CombatState);
            }
            
            if (CombatState)
            {
                if (states.WeaponEquipped)
                {
                    states.Animator.CrossFade(states.Hashes.CombatIdle, .3f, 1, 0f, 1f);
                }
                else
                {
                    states.Animator.CrossFade(states.Hashes.EquipWeapon, 0.2f);
                }
            }
            else
            {
                if (states.WeaponEquipped && !states.IsInCombat)
                {
                    states.Animator.CrossFade(states.Hashes.UnequipWeapon, 0.2f);
                }
            }
            
        }
    }
}

