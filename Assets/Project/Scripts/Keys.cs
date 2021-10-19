using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    private List<KeyData> keys;

    //public bool hasKey(KeyData keyData)
    //{
    //    return keys.Contains(keyData);
    //}

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
