using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeaclePool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject objectToPool;
    private List<GameObject> pooledObj = new List<GameObject>();
    [SerializeField] private int poolsize;
    private int idx = 0;
    void Start()
    {
        for (int i=0; i< poolsize;i++)
        {
            GameObject gobj=  Instantiate(objectToPool);
            gobj.transform.parent = gameObject.transform;
            gobj.SetActive(false);
            pooledObj.Add(gobj);

        }
    }
    public GameObject activateObject(Vector3 pos, Quaternion rot)
    {
        GameObject gObj = getPooledObj();

        if (gObj != null)
        {
            gObj.transform.position = pos;
            gObj.transform.rotation = rot;
            gObj.SetActive(true);
        }
        return gObj;
    }
    public GameObject getPooledObj()
    {
        foreach (GameObject gObj in pooledObj)
        {
            if (!gObj.activeInHierarchy) return gObj;
        }
        if (idx < pooledObj.Count) idx++;
        else idx = 0;
        return pooledObj[idx];
    }
}
