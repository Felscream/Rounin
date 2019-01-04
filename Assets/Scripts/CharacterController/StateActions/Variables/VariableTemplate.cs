using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VariableTemplate<T> : ScriptableObject
{
    public T value;

    public void SetValue(T v)
    {
        value = v;
    }
}
