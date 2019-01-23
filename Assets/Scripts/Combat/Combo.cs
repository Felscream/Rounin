using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

public struct ComboAttack
{
    public Vector2 Direction;
    public bool IsHeavy;

    public ComboAttack(Vector2 dir, bool heavy)
    {
        Direction = dir;
        IsHeavy = heavy;
    }
}

public class Combo : MonoBehaviour
{
    public delegate void AttackGetterCallback();
    public event AttackGetterCallback OnGetNextAttack = null;

    public bool CanCombo = true;
    public int MaxComboSize = 2;
    public static readonly ComboAttack Empty = new ComboAttack();

    private Queue<ComboAttack> _comboQueue = new Queue<ComboAttack>();
    private AnimatorData _animData;
    

    private int _attackCounter = 0;

    public void SetAnimator(AnimatorData a)
    {
        _animData = a;
    }

    public void AddToCombo(bool isAttacking, ComboAttack attack)
    {
        if(!_animData.Animator.GetBool("IsAttackingHeavy") && !_animData.Animator.GetBool("IsAttackingLight"))
        {
            _attackCounter = 0;
            CanCombo = true;
        }

        if (_attackCounter < MaxComboSize)
        {
            if ((!isAttacking || isAttacking && CanCombo) && _comboQueue.Count <= MaxComboSize)
            {
                CanCombo = false;
                _attackCounter++;
                _comboQueue.Enqueue(attack);
            }
        }
    }

    public ComboAttack GetNextAttack()
    {
        if(_comboQueue.Count > 0)
        {
            if(OnGetNextAttack != null)
            {
                OnGetNextAttack();
            }
            return _comboQueue.Dequeue();
        }
        return Empty;
    }

    public void SetCombo(int value)
    {
        CanCombo = value == 0 ? false : true;
    }
}
