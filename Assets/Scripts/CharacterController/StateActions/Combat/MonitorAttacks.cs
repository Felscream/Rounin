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
            if(states.InputVariables.RightTrigger > Constants.CombatThreshold)
            {
                if(states.GuardVariables.GuardDirection.x == 1f)
                {
                    states.Animator.CrossFade(states.Hashes.HeavyRight, .2f);
                    states.PlayerVariables.IsAttackingHeavy = true;
                    states.Animator.SetBool(states.Hashes.IsAttacking, true);
                }
                else if(states.GuardVariables.GuardDirection.x == -1f)
                {
                    states.Animator.CrossFade(states.Hashes.HeavyLeft, .2f);
                    states.PlayerVariables.IsAttackingHeavy = true;
                    states.Animator.SetBool(states.Hashes.IsAttacking, true);
                }

                states.InputVariables.RighTriggerReleased = false;
            }
        }
    }
}

