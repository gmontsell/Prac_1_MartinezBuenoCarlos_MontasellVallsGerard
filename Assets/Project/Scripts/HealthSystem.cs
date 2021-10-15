using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 200.0f;
    [SerializeField] DeaclePool decalepool;
    // Start is called before the first frame update
    public void takeDamage(float value)
    {
        health -= value;
        if (health <= 0.0f)
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.gameObject.layer == 2)
                {
                    child.transform.parent = decalepool.gameObject.transform;
                    child.gameObject.SetActive(false);
                }
            }
            Destroy(gameObject);
        }
    }

    public void lifeIncrease(float health_inc)
    {
        Debug.Log("Subiendo vidas");
        health += health_inc;
    }
}
