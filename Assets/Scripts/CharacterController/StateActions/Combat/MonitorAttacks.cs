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
            if(states.GuardVariables.GuardDirection != Vector2.zero)
            {
                
                if (states.InputVariables.RightTrigger > Constants.CombatThreshold && states.InputVariables.RightTriggerReleased)
                {
                    bool isAttacking = states.Animator.GetBool(states.Hashes.IsAttackingHeavy) || states.Animator.GetBool(states.Hashes.IsAttackingLight);
                    ComboAttack aa = new ComboAttack(states.GuardVariables.GuardDirection, true);
                    states.ComboManager.AddToCombo(isAttacking, aa);
                    states.InputVariables.RightTriggerReleased = false;
                }
                else if (states.InputVariables.RightShoulder)
                {
                    bool isAttacking = states.Animator.GetBool(states.Hashes.IsAttackingHeavy) || states.Animator.GetBool(states.Hashes.IsAttackingLight);
                    ComboAttack aa = new ComboAttack(states.GuardVariables.GuardDirection, false);
                    states.ComboManager.AddToCombo(isAttacking, aa);
                }
            }
        }
    }
}

