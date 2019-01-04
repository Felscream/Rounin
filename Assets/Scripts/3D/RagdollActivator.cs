using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivator : MonoBehaviour
{
    public GameObject BonesRoot;
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

        BonesRoot.gameObject.SetActive(value);
    }
}
