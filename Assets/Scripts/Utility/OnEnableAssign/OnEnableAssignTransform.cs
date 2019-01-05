using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

public class OnEnableAssignTransform : MonoBehaviour
{
    public TransformVariable TargetVariable;

    private void OnEnable()
    {
        TargetVariable.Set(GetComponent<Transform>());
    }
}
