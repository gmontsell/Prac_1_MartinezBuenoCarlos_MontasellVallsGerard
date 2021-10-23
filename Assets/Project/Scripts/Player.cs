using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        GetComponent<HealthSystem>().setDieFunction(
            died
            );
    }


    private void died()
    {
        Debug.Log("Muerto");
    }
}
