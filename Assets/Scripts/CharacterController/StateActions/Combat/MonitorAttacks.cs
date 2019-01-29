using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/MonitorAttacks")]
    public class MonitorAttacks : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.IsAttacking = states.Animator.GetBool(states.Hashes.IsAttackingHeavy) || states.Animator.GetBool(states.Hashes.IsAttackingLight);
            if (states.GuardVariables.GuardDirection != Vector2.zero && !states.Animator.GetBool(states.Hashes.IsInteracting))
            {
                
                if (states.InputVariables.RightTrigger > Constants.CombatThreshold && states.InputVariables.RightTriggerReleased)
                {
                    
                    ComboAttack aa = new ComboAttack(states.GuardVariables.GuardDirection, true);
                    states.ComboManager.AddToCombo(states.IsAttacking, aa);
                    states.InputVariables.RightTriggerReleased = false;
                }
                else if (states.InputVariables.RightShoulder)
                {
                    ComboAttack aa = new ComboAttack(states.GuardVariables.GuardDirection, false);
                    states.ComboManager.AddToCombo(states.IsAttacking, aa);
                }
            }
        }
    }
}

