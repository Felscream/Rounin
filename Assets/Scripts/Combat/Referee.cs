using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;
using Guard;

public static class Referee
{
    public static ParryData HasVictimParried(StateManager victim, StateManager Attacker, AttackSourceData attackData)
    {
        if (!victim.IsAttacking && victim.IsInCombat)
        {
            switch (attackData.RelativePosition)
            {
                case DamageSourceRelativePosition.Front:
                    {
                        switch(attackData.Direction)
                        {
                            case AttackDirection.Up:
                                {
                                    return new ParryData(victim.GuardVariables.ParryDirection == attackData.Direction, ParryType.FrontUp);
                                }
                            case AttackDirection.Right:
                                {
                                    return new ParryData(victim.GuardVariables.ParryDirection == AttackDirection.Left, ParryType.FrontLeft);
                                }
                            case AttackDirection.Left:
                                {
                                    return new ParryData(victim.GuardVariables.ParryDirection == AttackDirection.Right, ParryType.FrontRight);
                                }
                            default:
                                return new ParryData(false, ParryType.FrontRight);
                        }
                    }
                case DamageSourceRelativePosition.Right:
                    {
                        return new ParryData(victim.GuardVariables.ParryDirection == AttackDirection.Right, ParryType.Right);
                    }
                case DamageSourceRelativePosition.Left:
                    {
                        return new ParryData(victim.GuardVariables.ParryDirection == AttackDirection.Left, ParryType.Left);
                    }
                case DamageSourceRelativePosition.Back:
                    {
                        switch (attackData.Direction)
                        {
                            case AttackDirection.Right:
                                {
                                    return new ParryData(victim.GuardVariables.ParryDirection == AttackDirection.Right, ParryType.Right);
                                }
                            case AttackDirection.Left:
                                {
                                    return new ParryData(victim.GuardVariables.ParryDirection == AttackDirection.Left, ParryType.Left);
                                }
                            default:
                                return new ParryData(false, ParryType.Right);
                        }
                    }
                default:
                    return new ParryData(false, ParryType.Right);
            }
        }

        return new ParryData(false, ParryType.Right);
    }

    public static DamageSourceRelativePosition GetAttackerRelative2DPosition(Transform attacker, Transform victim)
    {
        Vector3 to = (victim.position - attacker.position).normalized;
        to.y = 0f;
        Vector3 from = victim.forward;
        from.y = 0f;

        float angle = Vector3.SignedAngle(from, to, Vector3.up);

        if (angle >= -45f && angle <= 45f)
        {
            return DamageSourceRelativePosition.Back;
        }
        else if (angle >= -135f && angle < 45f)
        {
            return DamageSourceRelativePosition.Right;
        }
        else if (angle > 45f && angle <= 135f)
        {
            return DamageSourceRelativePosition.Left;
        }
        return DamageSourceRelativePosition.Front;
    }
}
