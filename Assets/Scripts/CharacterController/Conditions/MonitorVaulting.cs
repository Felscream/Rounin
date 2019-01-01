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

        public VaultAnim[] VaultAnims;

        public override bool CheckCondition(StateManager state)
        {
            bool result = false;
            Vector3 origin = state.mTransform.position;
            origin.y += origin1Offset;

            Vector3 dir = state.mTransform.forward;
            
            Debug.DrawRay(origin, dir * ray1ForwardDist, Color.magenta);
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
                        VaultAnim v = CheckForVaultingAnim(state.mTransform.position, hit.point);

                        if (v != null)
                        {
                            state.Animator.SetBool(state.Hashes.IsInteracting, true);
                            state.Animator.CrossFade(v.AnimName, 0.2f);
                            state.VaultData.AnimLength = v.VaultAnimation.length;
                            state.VaultData.StartPosition = state.mTransform.position;
                            Vector3 endPosition = firstHit;
                            endPosition += normalDir * vaultOffsetPosition;
                            endPosition.y = hit.point.y;
                            state.VaultData.EndPosition = endPosition;

                            state.VaultData.isInit = false;
                            state.IsVaulting = true;
                        }
                    }
                }
            }

            return result;
        }

        public VaultAnim CheckForVaultingAnim(Vector3 origin, Vector3 hitPoint)
        {
            VaultAnim result = null;


            float diff = hitPoint.y - origin.y;

            for(int i = 0; i < VaultAnims.Length; ++i)
            {
                if(VaultAnims[i].DistanceFromGround - .05f < diff && VaultAnims[i].DistanceFromGround + .05f > diff)
                {
                    result = VaultAnims[i];
                    break;
                }
            }

            return result;
        }
    }
}

