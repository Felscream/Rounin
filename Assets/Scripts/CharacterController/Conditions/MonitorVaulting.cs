using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/MonitorVault")]
    public class MonitorVaulting : Condition
    {
        public LayerMask VaultLayer;
        public LayerMask GroundLayer;
        public float origin1Offset = 1f;
        public float origin2Offset = 0.2f;
        public float ray1ForwardDist = 1f;
        public float ray3ForwardDist = 2f;
        public float rayDownDist = 2f;
        public float vaultOffsetPosition = 1.5f;
        public AnimationClip VaultWalkClip;

        public override bool CheckCondition(StateManager state)
        {
            bool result = false;
            Vector3 origin = state.mTransform.position;
            origin.y += origin1Offset;

            Vector3 dir = state.mTransform.forward;
            
            Debug.DrawRay(origin, dir, Color.magenta);
            if(Physics.Raycast(origin, dir, out RaycastHit hit, ray1ForwardDist, VaultLayer))
            {
                Vector3 origin2 = origin;
                origin2.y += origin2Offset;
                Debug.DrawRay(origin2, dir, Color.magenta);

                Vector3 firstHit = hit.point;
                firstHit.y -= origin1Offset;

                Vector3 normalDir = -hit.normal;
                if (!Physics.Raycast(origin2, dir, ray1ForwardDist, VaultLayer))
                {
                    Vector3 origin3 = origin2 + dir * ray3ForwardDist;
                    Debug.DrawRay(origin3, -Vector3.up, Color.magenta, 30f);
                    if (Physics.Raycast(origin3, -Vector3.up, out hit, rayDownDist, GroundLayer))
                    {
                        result = true;
                        state.Animator.SetBool(state.Hashes.IsInteracting, true);
                        state.Animator.CrossFade(state.Hashes.VaultWalk, 0.2f);
                        
                        state.VaultData.isInit = false;
                        state.IsVaulting = true;

                        state.VaultData.AnimLength = VaultWalkClip.length;
                        state.VaultData.StartPosition = state.mTransform.position;

                        Vector3 endPosition = firstHit;
                        endPosition += normalDir * vaultOffsetPosition;
                        state.VaultData.EndPosition = endPosition;


                    }
                }
            }

            return result;
        }
    }
}

