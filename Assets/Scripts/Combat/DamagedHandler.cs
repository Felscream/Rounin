using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamagedHandler
{
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
        else if(angle >= -135f && angle < 45f)
        {
            return DamageSourceRelativePosition.Right;
        }
        else if(angle > 45f && angle <= 135f)
        {
            return DamageSourceRelativePosition.Left;
        }
        return DamageSourceRelativePosition.Front;
    }
}
