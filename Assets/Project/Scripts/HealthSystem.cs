using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 100.0f;
    // Start is called before the first frame update
    public void takeDamage(float value)
    {
        health -= value;
        if (health <= 0.0f) Destroy(gameObject);
    }
}
