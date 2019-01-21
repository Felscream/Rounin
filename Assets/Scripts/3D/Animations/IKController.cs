using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKController : MonoBehaviour
{
    
    public Transform RighHandObj;
    public Transform LeftHandObj;
    public Transform LookObj;

    public float GrabTime = 1f;

    private float _bias = 0f;
    private bool _ikActive = false;

    private Vector2 _ikTimeBounds;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _ikActive = !_ikActive;
            _ikTimeBounds.x = Time.time;
            if(_ikActive)
                _ikTimeBounds.y = _ikTimeBounds.x + GrabTime * (1 - _bias);
            else
                _ikTimeBounds.y = _ikTimeBounds.x + GrabTime * _bias;
        }
    }

    private void OnAnimatorIK()
    {
        
        if (_ikActive)
        {
            _bias = Mathf.Lerp(0f, 1f, (Time.time - _ikTimeBounds.x) / (_ikTimeBounds.y - _ikTimeBounds.x));
        }
        else
        {
            _bias = Mathf.Lerp(0f, 1f, 1 - (Time.time - _ikTimeBounds.x) / (_ikTimeBounds.y - _ikTimeBounds.x));
        }
        SetGoalsAndWeights(AvatarIKGoal.RightHand, _bias, RighHandObj);
        SetGoalsAndWeights(AvatarIKGoal.LeftHand, _bias, LeftHandObj);
    }

    private void SetGoalsAndWeights(AvatarIKGoal limb, float weight, Transform target)
    {
        if(weight > 0f)
        if (LookObj != null)
        {
            _animator.SetLookAtWeight(weight);
            _animator.SetLookAtPosition(LookObj.position);
        }

        if (RighHandObj != null)
        {
            _animator.SetIKPositionWeight(limb, weight);
            _animator.SetIKRotationWeight(limb, weight);
            
            _animator.SetIKPosition(limb, target.position);
            _animator.SetIKRotation(limb, target.rotation); 
        }
    }
}
