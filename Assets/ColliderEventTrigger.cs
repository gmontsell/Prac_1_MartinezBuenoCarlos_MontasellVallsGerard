using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEventTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent<Collider> onEnter;
    [SerializeField] UnityEvent<Collider> onExit;
    private void OnTriggerEnter(Collider other)
    {
        if (onEnter!=null)
        {
            onEnter.Invoke(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (onExit != null)
        {
            onExit.Invoke(other);
        }
    }
}
