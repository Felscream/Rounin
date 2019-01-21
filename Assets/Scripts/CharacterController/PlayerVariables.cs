using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using SA;
using Guard;

namespace Guard
{
    public enum GuardLocation
    {
        none,
        left,
        right,
        up
    }

[   System.Serializable]
    public class GuardLocationData
    {
        public GuardLocation Location;
        public Transform Target;
    }
}


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
    public Vector2 GuardDirection;
    public Vector2 LastGuardDirection;
    public GuardLocationData[] GuardData;

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

}
