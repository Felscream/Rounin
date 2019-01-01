using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace SA
{
    public class AnimatorHook : MonoBehaviour
    {
        public AnimatorData Data;

        private Dictionary<AvatarIKGoal, BodyPartIK> _ikDictionary;

        Animator _anim;

        private void Awake()
        {
            InitDictionnary();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            foreach(KeyValuePair<AvatarIKGoal, BodyPartIK> entry in _ikDictionary)
            {
                if(entry.Value != null)
                {
                    entry.Value.Execute(Data);
                }
            }
        }

        public void ChangeIKAction(AvatarIKGoal goal, BodyPartIK action)
        {
            if (_ikDictionary.ContainsKey(goal))
            {
                _ikDictionary[goal] = action;
            }
        }

        private void InitDictionnary()
        {
            _ikDictionary = new Dictionary<AvatarIKGoal, BodyPartIK>();
            AvatarIKGoal[] enumValues = (AvatarIKGoal[]) Enum.GetValues(typeof(HumanBodyBones));
            for (int i = 0; i < enumValues.Length; ++i)
            {
                _ikDictionary.Add(enumValues[i], null);
            }
        }
    }
}

