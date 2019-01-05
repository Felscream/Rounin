using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;

public class FollowPosition : MonoBehaviour
{
    public StateManager StateManagerToFollow;

    private Transform _toFollow;
    
    private void LateUpdate()
    {
        transform.position = StateManagerToFollow.mTransform.position;
    }
}
