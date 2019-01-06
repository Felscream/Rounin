using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{

    [CreateAssetMenu(menuName = "Actions/State Actions/Combat/MonitorWeaponEquipped")]
    public class MonitorWeaponEquipped : StateActions
    {
        public override void Execute(StateManager states)
        {
            if (!states.WeaponEquipped && !states.Animator.GetBool(states.Hashes.IsInteracting))
            {
                states.Animator.SetBool(states.Hashes.IsInteracting, true);
                states.Animator.CrossFade(states.Hashes.EquipWeapon, 0.2f);
            }
        }
    }
}

