using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/VaultMovement")]
    public class VaultMovement : StateActions
    {
        public override void Execute(StateManager states)
        {
            VaultData vd = states.VaultData;
            
            vd.vaultT += (states.delta * vd.VaultSpeed) / vd.AnimLength;

            if (!vd.isInit)
            {
                vd.vaultT = 0f;
                vd.isInit = true;

                Vector3 dir = vd.EndPosition - vd.StartPosition;
                Quaternion q = Quaternion.LookRotation(dir);
                states.mTransform.rotation = q;
            }
            if(vd.vaultT > 1f)
            {
                vd.isInit = false;
                states.IsVaulting = false;
            }

            Vector3 tarPosition = Vector3.Lerp(vd.StartPosition, vd.EndPosition, vd.vaultT);
            states.mTransform.position = tarPosition;
        }
    }
}

