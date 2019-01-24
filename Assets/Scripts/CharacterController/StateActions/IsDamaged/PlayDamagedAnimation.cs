using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    struct BlendData
    {
        public int Hash;
        public float BlendTime;

        public BlendData(int h, float t)
        {
            Hash = h;
            BlendTime = t;
        }
    }

    [CreateAssetMenu(menuName = "Actions/State Actions/Damaged/PlayDamagedAnimation")]
    public class PlayDamagedAnimation : StateActions
    {
        [Header("From Locomotion")]
        public float LeftBlendTime = 0.3f;
        public float RightBlendTime = 0.3f;
        public float DefaultBlendTime = 0.3f;
        public float FromCombatBlendTime = 0.2f;

        public override void Execute(StateManager states)
        {
            BlendData bd = GetBlendData(states);
            states.Animator.SetBool(states.Hashes.IsDamaged, true);
            states.Animator.CrossFade(bd.Hash, bd.BlendTime);
        }

        private BlendData GetBlendData(StateManager states)
        {
            if (!states.IsInCombat)
            {
                return FromLocomotion(states);
            }
            else
            {
                return FromCombat(states);
            }
        }

        private BlendData FromLocomotion(StateManager states)
        {
            int hash = 0;
            float time = 0f;

            switch (states.AttackReceivedData.RelativePosition)
            {
                case DamageSourceRelativePosition.Front:
                case DamageSourceRelativePosition.Back:
                    {
                        hash = states.Hashes.ReactionFront;
                        time = DefaultBlendTime;
                    }
                    break;
                case DamageSourceRelativePosition.Left:
                    {
                        hash = states.Hashes.ReactionLeft;
                        time = LeftBlendTime;
                    }
                    break;
                case DamageSourceRelativePosition.Right:
                    {
                        hash = states.Hashes.ReactionRight;
                        time = RightBlendTime;
                    }
                    break;
            }

            return new BlendData(hash, time);
        }

        private BlendData FromCombat(StateManager states)
        {
            int hash = 0;
            float time = FromCombatBlendTime;

            switch (states.AttackReceivedData.RelativePosition)
            {
                case DamageSourceRelativePosition.Front:
                    {
                        if (states.AttackReceivedData.Critical)
                        {
                            switch (states.AttackReceivedData.Direction)
                            {
                                case AttackDirection.Left:
                                    {
                                        hash = states.Hashes.ReactionHeavyFrontLeft;
                                    }
                                    break;
                                case AttackDirection.Right:
                                    {
                                        hash = states.Hashes.ReactionHeavyFrontRight;
                                    }
                                    break;
                                default:
                                    {
                                        hash = states.Hashes.ReactionHeavyFront;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            hash = states.Hashes.ReactionLightFront;
                        }

                    }
                    break;
                case DamageSourceRelativePosition.Left:
                    {
                        hash = states.AttackReceivedData.Critical ? states.Hashes.ReactionHeavyLeft : states.Hashes.ReactionLightLeft;
                    }
                    break;
                case DamageSourceRelativePosition.Right:
                    {
                        hash = states.AttackReceivedData.Critical ? states.Hashes.ReactionHeavyRight : states.Hashes.ReactionLightRight;
                    }
                    break;
                case DamageSourceRelativePosition.Back:
                    {
                        hash = states.AttackReceivedData.Critical ? states.Hashes.ReactionHeavyBack : states.Hashes.ReactionLightBack;
                    }
                    break;
            }
            return new BlendData(hash, time);
        }
    }
}

