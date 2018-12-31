using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPoolingTools;

[RequireComponent(typeof(MeshCollider))]
public class Cut : MonoBehaviour, IPooledObject
{
    public bool Visible = true;
    public Material Mat;
    private MeshCollider _collider;

    public Mesh Mesh
    {
        get { return _collider.sharedMesh; }
        set { ChangeMesh(value); }
    }

    public void OnSpawn()
    {
    }

    public void Reset()
    {
        gameObject.SetActive(false);
        transform.localPosition = Vector3.zero;
    }

    private void Awake()
    {
        _collider = GetComponent<MeshCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        Reset();
    }
    private void ChangeMesh(Mesh newMesh, bool activate = true)
    {
        _collider.sharedMesh = newMesh;

        if (Visible)
        {
            GameObject visual = new GameObject("DebugCut", new System.Type[2] { typeof(MeshFilter), typeof(MeshRenderer) });
            visual.transform.position = transform.position;
            visual.GetComponent<MeshFilter>().sharedMesh = newMesh;
            visual.GetComponent<MeshRenderer>().material = Mat;
            visual.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        }
    }
}
