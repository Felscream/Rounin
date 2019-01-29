using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using SA;
using Guard;

[System.Serializable]
public class PlayerVariables 
{
    public CinemachineBrain CinemachineBrain;
    public CinemachineCameras CinemachineCamera;
    public Transform CameraTransform;
    public Transform CombatCameraTransform;
    public Transform SwordHandAnchor;
    public PhysicMaterial SlideMaterial;
    [HideInInspector] public float IdleTimer = 0f;
    public Collider SwordCollider;
    public Transform CombatDefaultTarget;
    public bool IsAttackingHeavy;
}

[System.Serializable]
public class GuardVariables
{
    public float GuardTimer = 0f;
    public float MoveGuardTimer = 0f;
    public bool ChangedGuard;
    public ParryData ParryData = new ParryData();
    
    public Vector2 LastGuardDirection;
    public GuardLocationData[] GuardData;

    private Vector2 _guardDirection;

    public Vector2 GuardDirection
    {
        get { return _guardDirection; }
        set {
            _guardDirection = value;
            UpdateParryDirection();
        }
    }
    public AttackDirection ParryDirection { get; private set; }

    public GuardLocationData GetGuardLocation()
    {
        GuardLocation location = GuardLocation.none;
        if(GuardDirection.x == 1f)
        {
            location = GuardLocation.right;
        }
        else if(GuardDirection.x == -1f)
        {
            location = GuardLocation.left;
        }
        else if(GuardDirection.y == 1f)
        {
            location = GuardLocation.up;
        }
        return Array.Find(GuardData, x => x.Location == location);
    }

    public GuardLocationData GetLastGuardLocation()
    {
        GuardLocation location = GuardLocation.none;
        if (LastGuardDirection.x == 1f)
        {
            location = GuardLocation.right;
        }
        else if (LastGuardDirection.x == -1f)
        {
            location = GuardLocation.left;
        }
        else if (LastGuardDirection.y == 1f)
        {
            location = GuardLocation.up;
        }
        return Array.Find(GuardData, x => x.Location == location);
    }

    public void UpdateParryDirection()
    {
        if (GuardDirection.x == 1f)
            ParryDirection = AttackDirection.Right;
        else if (GuardDirection.x == -1f)
            ParryDirection = AttackDirection.Left;
        else if (GuardDirection.y == 1f)
            ParryDirection = AttackDirection.Up;
        else
            ParryDirection = AttackDirection.None;
    }

}
