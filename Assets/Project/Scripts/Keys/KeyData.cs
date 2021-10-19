using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "Items/Key", order = 2)]
public class KeyData : ScriptableObject
{
    [SerializeField] private string id;
    public bool canOpenDoor(string id)
    {
        return this.id.CompareTo(id)==0;
    }

    public string getId()
    {
        return this.id;
    }
}
