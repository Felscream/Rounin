using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

public class OnEnableAssignCombatCamera : MonoBehaviour
{
    public CinemachineFreeLookCameraVariable TargetVariable;

    private void OnEnable()
    {
        TargetVariable.combat = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        Destroy(this);  
    }
}
