using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Damaged/MoveWithDamagedRootMotion")]
    public class MoveWithDamagedRootMotion : StateActions
    {
        public float FromLocomotion = 0f;

        [Header("From Light Attacks")]
        public float LightFront = 1f;
        public float LightRight = 1f;
        public float LightLeft = 1f;
        public float LightBack = 1f;

        [Header("From Heavy Attacks")]
        public float HeavyFront = 1f;
        public float HeavyFrontLeft = 1f;
        public float HeavyLeft = 1f;
        public float HeavyFrontRight = 1f;
        public float HeavyRight = 1f;
        public float HeavyBack = 1f;

        public override void Execute(StateManager states)
        {
            float multiplier = ComputeMultiplier(states.IsInCombat, states.AttackReceivedData);

            states.Animator.transform.localPosition = Vector3.zero;
            states.Rigidbody.drag = 0f;
            Vector3 v = states.Rigidbody.velocity;
            Vector3 tarVelocity = states.Animator.deltaPosition;
            tarVelocity *= multiplier;
            tarVelocity.y = v.y;
            states.Rigidbody.velocity = tarVelocity;
        }

        private float ComputeMultiplier(bool combat, AttackSourceData data)
        {
            float multiplier = FromLocomotion;
            if (combat)
            {
                switch (data.RelativePosition)
                {
                    case DamageSourceRelativePosition.Front:
                        {
                            if (data.Critical)
                            {
                                switch (data.Direction)
                                {
                                    case AttackDirection.Left:
                                        {
                                            multiplier = HeavyFrontRight;
                                        }
                                        break;
                                    case AttackDirection.Right:
                                        {
                                            multiplier = HeavyFrontLeft;
                                        }
                                        break;
                                    default:
                                        {
                                            multiplier = HeavyFront;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                multiplier = LightFront;
                            }

                        }
                        break;
                    case DamageSourceRelativePosition.Left:
                        {
                            multiplier = data.Critical ? HeavyLeft : LightLeft;
                        }
                        break;
                    case DamageSourceRelativePosition.Right:
                        {
                            multiplier = data.Critical ? HeavyRight : LightRight;
                        }
                        break;
                    case DamageSourceRelativePosition.Back:
                        {
                            multiplier = data.Critical ? HeavyBack : LightBack;
                        }
                        break;
                }
            }

            return multiplier;
        }
    }
}

