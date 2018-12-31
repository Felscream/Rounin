using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCutter : MonoBehaviour
{
    public float Forward = 3f;
    public float Up = 1f;
    public float ScrollWeight = 5f;
    public LayerMask TargetLayer;
    private float _angle = 0f;
    private ObjectPooling _pool;

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), _angle.ToString());    
    }

    private void OnDrawGizmos()
    {
        Vector3 vUp = Quaternion.AngleAxis(_angle, transform.forward) * transform.up * Up;
        Vector3 vFo = transform.forward * Forward;
        Vector3[] planeCoordinates = new Vector3[3]
        {
            transform.position,
            transform.position + (vFo + vUp),
            transform.position + (vFo - vUp) 
        };

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(planeCoordinates[0], planeCoordinates[1]);
        Gizmos.DrawLine(planeCoordinates[1], planeCoordinates[2]);
        Gizmos.DrawLine(planeCoordinates[2], planeCoordinates[0]);
        Matrix4x4 m = new Matrix4x4();
        m.SetTRS(transform.position, Quaternion.LookRotation(transform.forward, vUp.normalized), Vector3.one);
        Gizmos.matrix = m;
        /*Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.matrix.rotation.SetLookRotation(Vector3.forward, vUp.normalized);*/
        Vector3 center = new Vector3(0f,0f, Forward / 2f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(center, new Vector3(0.05f, Up * 2f, Forward));
    }

    private void Start()
    {
        _pool = ObjectPooling.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreatePlane();
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            _angle += Input.GetAxis("Mouse ScrollWheel") * ScrollWeight * Time.deltaTime;
            _angle = Mathf.Repeat(_angle, 360f);
        }
    }

    private void CreatePlane()
    {
        Vector3 vUp = Quaternion.AngleAxis(_angle, transform.forward) * transform.up * Up;
        Vector3 vFo = transform.forward * Forward;
        Vector3[] vertices = new Vector3[3]
        {
            transform.position,
            transform.position + vFo + vUp,
            transform.position + vFo - vUp,
        };

        int[] triangles = new int[3] {0, 1, 2};
        Vector3 normal = Vector3.Cross(vertices[0] - vertices[1], vertices[0] - vertices[2]).normalized;

        Mesh plane = new Mesh
        {
            vertices = vertices,
            triangles = triangles
        };

        Vector3 center = transform.position + vFo / 2f;
        Collider[] hits = Physics.OverlapBox(center, new Vector3(0.1f, Up, Forward / 2f), Quaternion.AngleAxis(_angle, transform.forward), TargetLayer);
        Debug.Log(hits.Length);
        /*GameObject go = _pool.SpawnFromPool("Cut", Vector3.zero, Quaternion.identity);
        Cut c = go.GetComponent<Cut>();
        if (c != null)
        {
            c.Mesh = plane;
        }*/
    }
}
