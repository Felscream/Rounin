using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public abstract class AnimatorAction : ScriptableObject
    {
        public abstract void Execute(AnimatorData data);
    }
}

