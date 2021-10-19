using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 200.0f;
    [SerializeField] float max_health = 200.0f;
    [SerializeField] DeaclePool decalepool;

    [SerializeField] GameManager1 gameManager;

    private float initialHealth;

   

    public void OnEnable()
    {
        initialHealth = health;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            gameManager.gameOver();
    }


    public void takeDamage(float value)
    {
        health -= calculateDmg(value);
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

    internal void restart()
    {
        health = initialHealth;
    }

    private float calculateDmg(float act_dmg)
    {
        Shield shield = gameObject.GetComponent<Shield>();

       
            if (shield != null && shield.haveShield())
            {
                return shield.calculateDmg(act_dmg);
            }
            else
            {
                return act_dmg;
            }
       
        
    }

    public void lifeIncrease(float health_inc)
    {
        health += health_inc;
        health = Mathf.Min(health, max_health);
    }
}
