using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public List<KeyData> keys;
    private void Awake()
    {
        keys = new List<KeyData>();
    }

    public void addKey(KeyData key)
    {
        if (key != null) keys.Add(key);
    }
    public bool canOPen(string doorId)
    {
        foreach(KeyData k in keys)
        {
            if (k.canOpenDoor(doorId))
                return true;
        }
        return false;
    }
}
