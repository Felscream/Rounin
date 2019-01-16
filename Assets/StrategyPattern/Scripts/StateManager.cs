using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class StateManager : MonoBehaviour
    {
        public float health;
        
        public State currentState;
        
        public Animator Animator;
        public AnimatorHook AnimatorHook;
        public PlayerVariables PlayerVariables;
        public VaultData VaultData;
        [HideInInspector] public float delta;
        [HideInInspector] public Transform mTransform;
        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public Collider Collider;
        [HideInInspector] public float TimeSinceFall;

        public AnimHashes Hashes;
        public AnimatorData AnimData;

        [Header("DBG Input Variables")]
        [HideInInspector] public MovementVariables MovementVariables;
        [HideInInspector] public CameraVariables CameraVariables;
        [HideInInspector] public GeneralInputVariables InputVariables;

        public bool IsGrounded;
        public bool IsInCombat;
        public bool IsVaulting;
        public bool IsDodging;

        public bool CanMoveForward { get; set; }
        public bool IsBetweenObstacles { get; set; }
        public bool WeaponEquipped { get; set; }
        public Transform Target;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(PlayerVariables.CombatCameraTransform.position, Constants.FocusRange);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(PlayerVariables.CombatCameraTransform.position, Constants.FocusLossRange);
        }

        private void Awake()
        {
            if(Animator == null)
                Animator = GetComponentInChildren<Animator>();
            if (AnimatorHook == null)
            {
                AnimatorHook = GetComponentInChildren<AnimatorHook>();
            }
        }

        private void Start()
        {
            mTransform = transform;
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
            

            Hashes = new AnimHashes();
            AnimData = new AnimatorData(Animator);

            if(currentState != null)
            {
                currentState.OnEnter(this);
            }
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
