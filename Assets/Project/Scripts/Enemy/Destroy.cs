using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    public void patrol()
    {
        enemy.startPatrol();
    }
    public void destroy()
    {
        enemy.destroy();
    }

    public void lastState()
    {
        enemy.startLastState();
    }
}
