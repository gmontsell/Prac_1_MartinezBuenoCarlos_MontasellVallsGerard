using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] private KeyData keyData;

    public void consume(GameObject consumer)
    {
        Keys keys = consumer.GetComponent<Keys>();
        if (keys != null)
        {
            keys.addKey(keyData);
        }
        Destroy(gameObject);
    }
}
