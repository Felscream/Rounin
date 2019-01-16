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
        private bool _isUpdatingDictionnary = false;
        Animator _anim;

        private void OnEnable()
        {
            InitDictionnary();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            foreach (BodyPartIK entry in _ikDictionary.Values)
            {
                if (entry != null)
                {
                    entry.Execute(Data);
                }
            }

            if (LookAtActivated && LookAt != null)
            {
                Data.Animator.SetLookAtWeight(LookAt.Weight);
                Data.Animator.SetLookAtPosition(LookAt.Position);

            }
        }

        public void ChangeIKAction(BodyPartIK[] actions, bool reset = false)
        {
            _isUpdatingDictionnary = true;
            if (reset)
            {
                ResetDictionnary();
            }
            for(int i = 0; i < actions.Length; ++i)
            {
                if (!_ikDictionary.ContainsKey(actions[i].IKGoal))
                {
                    _ikDictionary.Add(actions[i].IKGoal,actions[i]);
                }
            }
            _isUpdatingDictionnary = false;
        }

        public void LookAtTarget(Vector3 target, float weight)
        {
            LookAt.Weight = weight;
            LookAt.Position = target;
            LookAtActivated = true;
        }

        private void ResetDictionnary()
        {
            if(_ikDictionary != null)
            {
                _ikDictionary.Clear();
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

