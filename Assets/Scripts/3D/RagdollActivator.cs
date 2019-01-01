using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivator : MonoBehaviour
{
    public Rigidbody[] _rbs;
    public Animator _animationController;

    private void Start()
    {
        _animationController = GetComponent<Animator>();
        SetRagdoll(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetRagdoll(true);
        }
    }
    public void SetRagdoll(bool value)
    {
        if(_animationController != null)
        {
            _animationController.enabled = !value;
        }

        for(int i = 0; i < _rbs.Length; ++i)
        {
            if(_rbs[i].gameObject != gameObject)
                _rbs[i].isKinematic = !value;
        }
    }
}
