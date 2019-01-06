using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [RequireComponent(typeof(Animator))]
    public class EquipWeapon : MonoBehaviour
    {
        public Transform Weapon;
        public Transform Holster;
        public Transform HandAnchor;
        public Vector3 HolsterPosition;
        public Vector3 HolsterRotation;
        public Vector3 HandAnchorPosition;
        public Vector3 HandAnchorRotation;

        public StateManager _stateManager;

        public void EquipWeaponToHand()
        {
            Weapon.parent = HandAnchor;
            Weapon.localPosition = HandAnchorPosition;
            Weapon.localRotation = Quaternion.Euler(HandAnchorRotation);
            _stateManager.WeaponEquipped = true;
        }

        public void UnequipWeapon()
        {
            Weapon.parent = Holster;
            Weapon.localPosition = HolsterPosition;
            Weapon.localRotation = Quaternion.Euler(HolsterRotation);
            _stateManager.WeaponEquipped = false;
        }
    }
}

