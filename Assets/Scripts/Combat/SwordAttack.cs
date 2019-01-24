using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

public class SwordAttackData
{
    public Vector2 Direction;
    public float Damage;
    public bool IsHeavy;
}

public struct DamageReceivedData
{
    public DamageSourceRelativePosition RelativePosition;
    public bool IsHeavy;

    public DamageReceivedData(DamageSourceRelativePosition pos, bool heavy)
    {
        RelativePosition = pos;
        IsHeavy = heavy;
    }
}

[RequireComponent(typeof(Collider))]

public class SwordAttack : MonoBehaviour
{
    public StateManager Origin;
    public SwordAttackData AttackData = new SwordAttackData();

    private List<StateManager> DamagedList;

    private void Start()
    {
        DamagedList = new List<StateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StateManager victim = other.GetComponent<StateManager>();
        
        if(victim != null && !HasAlreadyBeenDamaged(victim) && victim != Origin)
        {
            victim.HealthManager.ReduceHealth(BuildAttackData(victim.mTransform));
            DamagedList.Add(victim);
        }
    }

    public void InitNewAttack(Vector2 direction, float damage, bool heavy)
    {
        AttackData.Direction = direction;
        AttackData.Damage = damage;
        AttackData.IsHeavy = heavy;
    }

    public void ClearDamagedList()
    {
        DamagedList.Clear();
    }

    private bool HasAlreadyBeenDamaged(StateManager sm)
    {
        for(int i = 0; i < DamagedList.Count; ++i)
        {
            if(sm == DamagedList[i])
            {
                return true;
            }
        }
        return false;
    }

    private AttackSourceData BuildAttackData(Transform victimTransform)
    {
        DamageSourceRelativePosition pos = DamagedHandler.GetAttackerRelative2DPosition(Origin.mTransform, victimTransform);
        AttackDirection dir = AttackDirection.Up;
        if(AttackData.Direction.x == 1f)
        {
            dir = AttackDirection.Right;
        }
        else if(AttackData.Direction.x == -1f)
        {
            dir = AttackDirection.Left;
        }

        return new AttackSourceData(Origin, AttackData.Damage, AttackData.IsHeavy, dir, DamageSourceType.Sword, pos);
    }
}
