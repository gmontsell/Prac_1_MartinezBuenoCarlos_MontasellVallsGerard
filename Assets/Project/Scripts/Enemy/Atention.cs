using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atention : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Alert");
        enemy.startAlert();
    }
}
