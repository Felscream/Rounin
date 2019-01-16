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
}
