using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmJoint : MonoBehaviour
{
    public Vector3 Axis;
    public Transform Target;

    public ArmJoint[] Joints;
    public float SamplingDistance = 0.5f;
    public float LearningRate = 0.5f;
    public float DistanceThreshold = 0.3f;

    private Vector3 _offset;
    public Vector3 Offset { get { return _offset; } }

    private void Start()
    {
        _offset = transform.localPosition;
    }

    private void Update()
    {
        if(Joints.Length > 0)
        {
            float[] a = new float[Joints.Length];
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = Joints[i].transform.rotation.eulerAngles.y;
            }

            InverseKinematics(Target.position, a);
        }
        
    }

    public Vector3 ForwardKinematics(float[] angles)
    {
        Vector3 prevPoint = Joints[0].transform.position;
        Quaternion rotation = Quaternion.identity;
        for(int i = 1; i < Joints.Length; ++i)
        {
            rotation *= Quaternion.AngleAxis(angles[i - 1], Joints[i - 1].Axis);
            Vector3 nextPoint = prevPoint + rotation * Joints[i].Offset;
            prevPoint = nextPoint;
        }

        return prevPoint;
    }

    public float DistanceToTarget(Vector3 target, float[] angles)
    {
        Vector3 p = ForwardKinematics(angles);
        return Vector3.Distance(p, target);
    }
    
    public float PartialGradient(Vector3 target, float[] angles, int i)
    {
        float angle = angles[i];

        float f_x = DistanceToTarget(target, angles);

        angles[i] += SamplingDistance;

        float f_x_distance = DistanceToTarget(target, angles);

        float gradient = (f_x_distance - f_x) / SamplingDistance;

        angles[i] = angle;

        return gradient;
    }

    public void InverseKinematics(Vector3 target, float[] angles)
    {
        if(DistanceToTarget(target, angles) < DistanceThreshold)
        {
            return;
        }

        for(int i = Joints.Length - 1; i >=0 ; --i)
        {
            float gradient = PartialGradient(target, angles, i);
            angles[i] -= LearningRate * gradient;
            Joints[i].transform.rotation = Quaternion.AngleAxis(angles[i], Joints[i].Axis);
            if (DistanceToTarget(target, angles) < DistanceThreshold)
                return;
        }
    }
}
