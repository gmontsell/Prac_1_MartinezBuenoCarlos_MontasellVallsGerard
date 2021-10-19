using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animation anim;
    [SerializeField] private KeyData key;
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            anim.CrossFade("door_Open");
            Debug.Log("AAAAA");
            //se abre la puerta
            isOpen = true;
        }

    }
}
