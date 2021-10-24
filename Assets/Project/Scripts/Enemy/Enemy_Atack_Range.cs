using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Atack_Range : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    private void OnTriggerEnter(Collider other)
    {
        enemy.startAttack();
    }
    private void OnTriggerExit(Collider other)
    {
        enemy.startChasing();
    }
}
