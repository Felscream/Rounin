﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace SA
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(HealthManager))]
    public class StateManager : MonoBehaviour
    {
        public State currentState;
        [Header("Animation")]
        public Animator Animator;
        public AnimatorHook AnimatorHook;
        
        [Header("Player Variables")]
        public PlayerVariables PlayerVariables;
        public GuardVariables GuardVariables;
        public VaultData VaultData;
        public SwordAttack Sword;
        public Combo ComboManager;
        public Transform Target;
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

        [Header("State boolean")]
        public bool IsGrounded;
        public bool IsInCombat;
        public bool IsVaulting;
        public bool IsDodging;
        public bool IsRunning;
        
        public bool CanMoveForward { get; set; }
        public bool IsBetweenObstacles { get; set; }
        public bool AttackInitialized { get; set; }
        public bool WeaponEquipped { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsAttacking { get; set; }
        public ComboAttack CurrentAttack { get; set; }
        public HealthManager HealthManager { get; private set; }
        public AttackSourceData AttackReceivedData { get; private set; }

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
            HealthManager = GetComponent<HealthManager>();

            ComboManager.OnGetNextAttack += Sword.ClearDamagedList;
            HealthManager.OnHealthReduction += OnHealthReduction;
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

        private void OnDisable()
        {
            ComboManager.OnGetNextAttack -= Sword.ClearDamagedList;
            HealthManager.OnHealthReduction -= OnHealthReduction;
        }

        public void ReceiveAttack(AttackSourceData attackData)
        {
            GuardVariables.ParryData = Referee.HasVictimParried(this, attackData.Attacker, attackData);
            if (!GuardVariables.ParryData.HasParried)
            {
                HealthManager.ReduceHealth(attackData);
            }
        }

        private void OnHealthReduction(AttackSourceData attackData)
        {
            AttackReceivedData = attackData;
            IsDamaged = true;
        }
    }
}
