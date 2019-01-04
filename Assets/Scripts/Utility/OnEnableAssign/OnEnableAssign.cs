using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OnEnableAssign<T> : MonoBehaviour
{
    public VariableTemplate<T> TargetVariable;

    private void OnEnable()
    {
        TargetVariable.value = GetComponent<T>();
    }
}
