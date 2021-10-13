using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConsumer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entra");
        Item item = other.GetComponent<Item>();
        if (item != null) item.consume(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (gameObject.TryGetComponent(out Item it))
    //    {
    //        it.consume(gameObject);
    //    }
    //}
}
