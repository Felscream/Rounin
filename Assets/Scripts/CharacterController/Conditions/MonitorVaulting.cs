using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/MonitorVault")]
    public class MonitorVaulting : Condition
    {
        public LayerMask VaultLayer;
        public float origin1Offset = 1f;
        public float origin2Offset = 0.2f;
        public float rayForwardDist = 1f;
        public float rayDownDist = 2f;

        public override bool CheckCondition(StateManager state)
        {
            bool result = false;
            Vector3 origin = state.mTransform.position;
            origin.y += origin1Offset;

            Vector3 dir = state.mTransform.forward;
            
            Debug.DrawRay(origin, dir, Color.magenta);
            if(Physics.Raycast(origin, dir, out RaycastHit hit, rayForwardDist, VaultLayer))
            {
                Vector3 origin2 = origin;
                origin2.y += origin2Offset;
                Debug.DrawRay(origin2, dir, Color.magenta);
                if (!Physics.Raycast(origin2, dir, rayForwardDist, VaultLayer))
                {
                    Vector3 origin3 = origin2 + dir * rayForwardDist * 1.75f;
                    Debug.DrawRay(origin3, -Vector3.up, Color.magenta);
                    if (Physics.Raycast(origin3, -Vector3.up, out hit, rayDownDist))
                    {
                        result = true;
                        state.Animator.SetBool(state.Hashes.IsInteracting, true);
                        state.Animator.CrossFade(state.Hashes.VaultWalk, 0.2f);
                        state.VaultData.StartPosition = state.mTransform.position;
                        state.VaultData.EndPosition = hit.point;
                        state.VaultData.isInit = false;
                        state.IsVaulting = true;
                    }
                }
            }

            return result;
        }
    }
}

