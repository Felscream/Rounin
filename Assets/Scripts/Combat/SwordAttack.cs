using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

[RequireComponent(typeof(Collider))]
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
    private Collider _swordCollider;

    public bool CanBeEnabled { get; set; }

    private void Start()
    {
        DamagedList = new List<StateManager>();
        _swordCollider = GetComponent<Collider>();
        InitSwordCollider();
    }

    private void OnTriggerEnter(Collider other)
    {
        StateManager victim = other.GetComponent<StateManager>();
        
        if(victim != null && !HasAlreadyBeenDamaged(victim) && victim != Origin)
        {
            victim.ReceiveAttack(BuildAttackData(victim.mTransform));
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

    public void DisableSwordCollider()
    {
        _swordCollider.enabled = false;
    }

    public void EnableSwordCollider()
    {
        if(CanBeEnabled)
            _swordCollider.enabled = true;
    }

    public void SetSwordColliderActivation(bool value)
    {
        CanBeEnabled = value;
        if (!value)
            DisableSwordCollider();
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
        DamageSourceRelativePosition pos = Referee.GetAttackerRelative2DPosition(Origin.mTransform, victimTransform);
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

    private void InitSwordCollider()
    {
        _swordCollider.isTrigger = true;
        _swordCollider.enabled = false;
    }
}
