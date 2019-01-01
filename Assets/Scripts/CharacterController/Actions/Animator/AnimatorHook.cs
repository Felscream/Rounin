using UnityEngine;
using System.Collections;

namespace SA
{
    public class AnimatorHook : MonoBehaviour
    {
        public AnimatorData Data;
        public AnimatorAction[] actions;

        Animator _anim;

        private void OnAnimatorIK(int layerIndex)
        {
            for(int i = 0; i < actions.Length; ++i)
            {
                actions[i].Execute(Data);
            }
        }
    }
}

