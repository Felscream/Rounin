using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class ToggleHandIK : StateActions
    {
        public bool Activate;
        public override void Execute(StateManager states)
        {
            states.AnimatorHook.HandsOnWeaponActivated = Activate;
        }
    }
}

