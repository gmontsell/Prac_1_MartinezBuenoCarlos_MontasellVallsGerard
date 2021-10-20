using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConsumer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        KeyItem key = other.GetComponent<KeyItem>();
        if (item != null) item.consume(gameObject);
        if (key != null ) key.consume(gameObject);
    }
}
