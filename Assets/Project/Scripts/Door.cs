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
        if (other.gameObject.GetComponent<Player>()
            &&!isOpen
            &&other.gameObject.GetComponent<Keys>().canOPen(key.getId()))
        {
            anim.CrossFade("door_Open"); //FALTA HACERLA
            isOpen = true;
        }

    }
}
