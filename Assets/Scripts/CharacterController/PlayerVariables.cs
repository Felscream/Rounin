using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;
using SO;

[CreateAssetMenu(menuName = "PlayerVariable")]
public class PlayerVariables : ScriptableObject
{
    public CinemachineBrainVariable CinemachineBrain;
    public CinemachineFreeLookCameraVariable CinemachineCamera;
    public TransformVariable CameraTransform;
    public TransformVariable CombatCameraTransform;
    public PhysicMaterial SlideMaterial;
}
