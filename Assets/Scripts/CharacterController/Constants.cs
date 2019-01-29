using UnityEngine;

namespace Guard
{
    public enum GuardLocation
    {
        none,
        left,
        right,
        up
    }

    [System.Serializable]
    public class GuardLocationData
    {
        public GuardLocation Location;
        public Transform Target;
    }

    public enum ParryType
    {
        FrontUp,
        FrontLeft,
        FrontRight,
        Left,
        Right,
        Back
    }

    public class ParryData
    {
        public bool HasParried;
        public ParryType Parry;

        public ParryData()
        {
            HasParried = false;
            Parry = ParryType.FrontUp;
        }

        public ParryData(bool parried, ParryType type)
        {
            HasParried = parried;
            Parry = type;
        }
    }
}

public enum DamageSourceType
{
    Self,
    Sword,
    Unknown
}

public enum DamageSourceRelativePosition
{
    Front,
    Left,
    Right,
    Back
}

public enum AttackDirection
{
    Up,
    Left,
    Right,
    None
}

public static class Constants
{
    public static float MovementThreshold = 0.1f;
    public static float RunThreshold = 0.6f;
    public static float CombatThreshold = 0.6f;
    public static float FocusRange = 12f;
    public static float FocusLossRange = 15f;
    public static float ResetGuardTime = 3f;
    public static float TimeToMoveGuard = .25f;
    public static Vector2 LookAtAngle = new Vector2(0.3f, 0.6f);

    public static float HeavyBaseDamage = 300f;
    public static float LightBaseDamage = 100f;
    public static float HeavyUpBaseDamage = 400f;
}
