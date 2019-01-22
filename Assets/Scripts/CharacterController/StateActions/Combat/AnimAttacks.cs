using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/AnimAttacks")]
    public class AnimAttacks : StateActions
    {
        public override void Execute(StateManager states)
        {
            ComboAttack attack = states.ComboManager.GetNextAttack();
            if(attack.Direction != Vector2.zero)
            {
                states.AnimatorHook.HandsOnWeaponActivated = false;
                if (attack.IsHeavy)
                {
                    HeavyAttacks(states, attack);
                }
                else
                {
                    LightAttacks(states, attack);
                }
            }
        }

        private void HeavyAttacks(StateManager states, ComboAttack attack)
        {
            if (attack.Direction.x == 1f)
            {
                states.Animator.CrossFade(states.Hashes.HeavyRight, .2f);
                states.PlayerVariables.IsAttackingHeavy = true;
                states.Animator.SetBool(states.Hashes.IsAttackingHeavy, true);
            }
            else if (attack.Direction.x == -1f)
            {
                states.Animator.CrossFade(states.Hashes.HeavyLeft, .2f);
                states.PlayerVariables.IsAttackingHeavy = true;
                states.Animator.SetBool(states.Hashes.IsAttackingHeavy, true);
            }
            else if (attack.Direction.y == 1f)
            {
                states.Animator.CrossFade(states.Hashes.HeavyUp, .2f);
                states.PlayerVariables.IsAttackingHeavy = true;
                states.Animator.SetBool(states.Hashes.IsAttackingHeavy, true);
            }
        }

        private void LightAttacks(StateManager states, ComboAttack attack)
        {
            if (attack.Direction.x == 1f)
            {
                states.Animator.CrossFade(states.Hashes.LightRight, .2f);
                states.PlayerVariables.IsAttackingHeavy = false;
                states.Animator.SetBool(states.Hashes.IsAttackingLight, true);
            }
            else if (attack.Direction.x == -1f)
            {
                states.Animator.CrossFade(states.Hashes.LightLeft, .2f);
                states.PlayerVariables.IsAttackingHeavy = false;
                states.Animator.SetBool(states.Hashes.IsAttackingLight, true);
            }
            /*else if (states.GuardVariables.GuardDirection.y == 1f)
            {
                states.Animator.CrossFade(states.Hashes.HeavyUp, .2f);
                states.PlayerVariables.IsAttackingHeavy = false;
                states.Animator.SetBool(states.Hashes.IsAttacking, true);
            }*/
        }
    }
}

