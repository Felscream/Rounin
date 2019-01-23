using UnityEngine;

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
