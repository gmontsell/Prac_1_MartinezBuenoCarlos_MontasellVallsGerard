using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public delegate void DieFunction();


public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 200.0f;
    [SerializeField] float max_health = 200.0f;
    [SerializeField] DeaclePool decalepool;

    [SerializeField] GameManager1 gameManager;
    [SerializeField] private UnityEvent<int> pointChanged;

    private float initialHealth;
    private DieFunction die;


    public void setDieFunction(DieFunction die)
    {
        this.die = die;
    }


    public void OnEnable()
    {
        initialHealth = health;
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            die();
    }


    public void takeDamage(float value)
    {
        health -= calculateDmg(value);
        if (health <= 0.0f)
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            bool haveDecal = false;
            foreach (Transform child in allChildren)
            {
                Debug.Log(child);
                if (child.gameObject.layer==2) haveDecal = true;

            }

            if (haveDecal)
            {
                for (int i = 0; i < allChildren.Length; i++)
                {
                    Debug.Log(i);
                    Debug.Log(allChildren[i]);
                    if (allChildren[i].gameObject.layer == 2)
                    {
                        allChildren[i].gameObject.SetActive(false);
                        allChildren[i].transform.parent = decalepool.gameObject.transform;
                    }
                }
                Destroy(gameObject);
            }
            else Destroy(gameObject);
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
