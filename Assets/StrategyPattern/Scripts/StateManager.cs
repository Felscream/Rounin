using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(Rigidbody))]
    public class StateManager : MonoBehaviour
    {
        public float health;
        
        public State currentState;

        public MovementVariables MovementVariables;

        [HideInInspector] public float delta;
        [HideInInspector] public Transform mTransform;
        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public Animator Animator;
        [HideInInspector] public float TimeSinceFall;
        [HideInInspector] public float TimeSinceGrounded;

        public AnimHashes Hashes;
        public AnimatorData AnimData;

        public bool IsGrounded;

        public bool CanMoveForward { get; set; }
        public bool IsBetweenObstacles { get; set; }

        private void Start()
        {
            mTransform = transform;
            Rigidbody = GetComponent<Rigidbody>();
            Animator = GetComponentInChildren<Animator>();
            Hashes = new AnimHashes();
            AnimData = new AnimatorData(Animator);
        }

        private void FixedUpdate()
        {
            delta = Time.fixedDeltaTime;
            if(currentState != null)
            {
                currentState.FixedTick(this);
            }
        }
        
        private void Update()
        {
            delta = Time.deltaTime;
            if(currentState != null)
            {
                currentState.Tick(this);
            }
        }
    }
}
