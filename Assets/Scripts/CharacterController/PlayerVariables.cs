using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using SA;

[System.Serializable]
public class PlayerVariables 
{
    public CinemachineBrain CinemachineBrain;
    public CinemachineCameras CinemachineCamera;
    public Transform CameraTransform;
    public Transform CombatCameraTransform;
    public PhysicMaterial SlideMaterial;
    [HideInInspector] public float IdleTimer = 0f;
    public float GuardTimer = 0f;
    public Vector2 GuardDirection;
    public Collider SwordCollider;
    public Transform CombatDefaultTarget;
    public bool IsAttackingHeavy;
}
