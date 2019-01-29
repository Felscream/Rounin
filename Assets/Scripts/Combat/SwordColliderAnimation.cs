using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;
public class SwordColliderAnimation : MonoBehaviour
{
    public StateManager StateManager;

    public void EnableSwordCollider()
    {
        StateManager.Sword.EnableSwordCollider();
    }

    public void DisableSwordCollider()
    {
        StateManager.Sword.DisableSwordCollider();
    }
}
