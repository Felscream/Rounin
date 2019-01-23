using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

public struct AttackSourceData
{
    public StateManager Attacker;
    public float Damage;
    public bool Critical;
    public DamageSourceType AttackType;
    public DamageSourceRelativePosition RelativePosition;

    public AttackSourceData(StateManager attacker, float damage, bool critical, DamageSourceType type, DamageSourceRelativePosition pos)
    {
        Attacker = attacker;
        Damage = damage;
        Critical = critical;
        AttackType = type;
        RelativePosition = pos;
    }
}

public class HealthManager : MonoBehaviour
{
    public delegate void HealthReductionCallback(AttackSourceData attackData);
    public event HealthReductionCallback OnHealthReduction = null;
    public float BaseHealth = 1000f;

    public void ReduceHealth(AttackSourceData attackData)
    {
        BaseHealth = Mathf.Max(BaseHealth - attackData.Damage, 0);
        Debug.Log(transform.parent.name+" :: Received " + attackData.Damage + " by " + attackData.Attacker.transform.parent.name);

        if(OnHealthReduction != null && attackData.Damage > 0f)
        {
            OnHealthReduction(attackData);
        }
    }
}
