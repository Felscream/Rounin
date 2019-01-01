using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocation : MonoBehaviour
{
    public Transform ToTeleport;
    public bool ActivateTeleportation;

    private void Update()
    {
        if (ActivateTeleportation && ToTeleport != null)
        {
            ToTeleport.position = transform.position;
        }
        ActivateTeleportation = false;
    }
}
