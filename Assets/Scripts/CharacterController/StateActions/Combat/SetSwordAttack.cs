using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/SetSwordAttack")]
    public class SetSwordAttack : StateActions
    {
        public override void Execute(StateManager states)
        {
            if (!states.AttackInitialized)
            {
                float damage = 0f;
                Vector2 dir = states.CurrentAttack.Direction;
                if (states.CurrentAttack.IsHeavy)
                {
                    if (dir.y == 1f)
                    {
                        damage = Constants.HeavyUpBaseDamage;
                    }
                    else
                    {
                        damage = Constants.HeavyBaseDamage;
                    }
                }
                else if (dir.y == 0 && dir.x != 0)
                {
                    damage = Constants.LightBaseDamage;
                }

                states.Sword.InitNewAttack(dir, damage, states.CurrentAttack.IsHeavy);
                states.AttackInitialized = true;
            }
        }
    }
}

