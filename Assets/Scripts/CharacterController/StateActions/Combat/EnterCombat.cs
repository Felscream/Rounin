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
            states.Animator.SetBool(states.Hashes.CombatMode, CombatState);
            
            if (states.WeaponEquipped && !CombatState && states.IsGrounded)
            {
                states.Animator.CrossFade(states.Hashes.UnequipWeapon, 0.2f);
            }
            
        }
    }
}

