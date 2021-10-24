using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HealthSystem hs = other.GetComponent<HealthSystem>();
        if (hs != null) hs.takeDamage(100);
    }
}

