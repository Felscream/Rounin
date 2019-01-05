using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMoveFollow : MonoBehaviour
{
    public Animator Animator;

    void OnAnimatorMove()
    {
        if (Animator != null && !Mathf.Approximately(0f, Animator.deltaPosition.y)) {
            Vector3 newPosition = transform.parent.position;
            newPosition.y += Animator.deltaPosition.y;
            newPosition.x += Animator.deltaPosition.x;
            newPosition.z += Animator.deltaPosition.z;
            transform.parent.position = newPosition;
        }
    }
}
