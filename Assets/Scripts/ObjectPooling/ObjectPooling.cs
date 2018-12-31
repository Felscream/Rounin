using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPoolingTools;

public class ObjectPooling : MonoBehaviour
{
    public Pool[] Pools;

    private Dictionary<string, Queue<GameObject>> _poolDictionnary;

    private static ObjectPooling _instance;
    public static ObjectPooling Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("No instance of ObjectPooling found");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            InitializePools();
        }
        else
        {
            DestroyImmediate(gameObject);
        } 
    }

    public GameObject SpawnFromPool(string code, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionnary.ContainsKey(code))
        {
            Debug.LogError(gameObject.name + " :: dictionnary doesn't contain key '" + code + "'");
            return null;
        }

        GameObject toSpawn = _poolDictionnary[code].Dequeue();
        toSpawn.transform.position = position;
        toSpawn.transform.rotation = rotation;
        toSpawn.SetActive(true);

        IPooledObject obj = toSpawn.GetComponent<IPooledObject>();
        if(obj != null)
        {
            obj.OnSpawn();
        }

        _poolDictionnary[code].Enqueue(toSpawn);

        return toSpawn;
    }

    private void InitializePools()
    {
        _poolDictionnary = new Dictionary<string, Queue<GameObject>>();
        for(int i = 0; i < Pools.Length; ++i)
        {
            GameObject parent = new GameObject(Pools[i].Code+"s("+Pools[i].Size.ToString()+")");
            parent.transform.parent = transform;
            parent.transform.localPosition = Vector3.zero;

            Queue<GameObject> objectQueue = new Queue<GameObject>();
            for(int j = 0; j < Pools[i].Size; ++j)
            {
                GameObject obj = Instantiate(Pools[i].ObjectPrefab, parent.transform);
                obj.SetActive(false);
                objectQueue.Enqueue(obj);
            }

            if(objectQueue.Count > 0)
                _poolDictionnary.Add(Pools[i].Code, objectQueue);
        }
    }
}
