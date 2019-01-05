using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RagdollActivator : MonoBehaviour
{
    public Rigidbody[] RagDollRigidBodies;
    public Collider[] RagDollColliders;
    private Animator _animationController;

    private void Awake()
    {
        _animationController = GetComponent<Animator>();
        ActivateRagDoll(false);
    }

    public void ActivateRagDoll(bool value)
    {
        for(int i = 0; i < RagDollRigidBodies.Length; ++i)
        {
            if(RagDollRigidBodies[i] != null)
            {
                RagDollRigidBodies[i].isKinematic = !value;
            }
           /* if (RagDollColliders[i] != null)
                RagDollColliders[i].enabled = value;*/
        }

        if(_animationController != null)
        {
            _animationController.enabled = !value;
        }
    }
}
