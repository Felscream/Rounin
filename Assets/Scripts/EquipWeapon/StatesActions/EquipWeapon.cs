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

        public void EquipWeaponToHand()
        {
            Weapon.parent = HandAnchor;
            Weapon.localPosition = HandAnchorPosition;
            Weapon.rotation = Quaternion.Euler(HandAnchorRotation);
        }

        public void UnequipWeapon()
        {
            Weapon.parent = Holster;
            Weapon.localPosition = HolsterPosition;
            Weapon.rotation = Quaternion.Euler(HolsterRotation);
        }
    }
}

