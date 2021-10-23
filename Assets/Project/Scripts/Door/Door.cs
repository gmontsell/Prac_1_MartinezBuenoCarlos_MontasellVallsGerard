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
        if (key!=null) {
            if (other.gameObject.GetComponent<Player>()
                && !isOpen
                && other.gameObject.GetComponent<Keys>().canOPen(key.getId()))
            {
                Debug.Log("Opening door");
                anim.CrossFade("Open_door");
                isOpen = true;
            }
        }
        else
        {
            if (other.gameObject.GetComponent<Player>() && !isOpen)
            {
                anim.CrossFade("Open_door");
                isOpen = true;
            }
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            anim.CrossFade("Close_door");
            isOpen = false;
        }
    }
}
