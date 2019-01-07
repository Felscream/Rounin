using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

namespace SA
{
    public class IKLookAtTarget
    {
        public float Weight;
        public Vector3 Position;
    }

    public class AnimatorHook : MonoBehaviour
    {
        public AnimatorData Data;
        public IKLookAtTarget LookAt = new IKLookAtTarget();
        public bool LookAtActivated = false;

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

            if (LookAtActivated && LookAt != null)
            {
                Data.Animator.SetLookAtWeight(LookAt.Weight);
                Data.Animator.SetLookAtPosition(LookAt.Position);

            }
        }

        public void ChangeIKAction(AvatarIKGoal goal, BodyPartIK action)
        {
            if (_ikDictionary.ContainsKey(goal))
            {
                _ikDictionary[goal] = action;
            }
        }

        public void LookAtTarget(Vector3 target, float weight)
        {
            LookAt.Weight = weight;
            LookAt.Position = target;
            LookAtActivated = true;
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

