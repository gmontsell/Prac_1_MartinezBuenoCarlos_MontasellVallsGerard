using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public delegate void DieFunction();


public class HealthSystem : MonoBehaviour
{
    [SerializeField] float health = 200.0f;
    [SerializeField] float max_health = 200.0f;
    [SerializeField] DeaclePool decalepool;

    [SerializeField] GameManager1 gameManager;
    [SerializeField] private UnityEvent<int> pointChanged;

    [SerializeField]  Slider slider;

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

    public void Start()
    {
        actSlider();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            die();
    }


    public void takeDamage(float value)
    {
        health -= calculateDmg(value);
        actSlider();
        if (health <= 0.0f)
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            bool haveDecal = false;
            foreach (Transform child in allChildren)
            {
                if (child.gameObject.layer==2) haveDecal = true;

            }

            if (haveDecal)
            {
                for (int i = 0; i < allChildren.Length; i++)
                {
                    if (allChildren[i].gameObject.layer == 2)
                    {
                        allChildren[i].gameObject.SetActive(false);
                        allChildren[i].transform.parent = decalepool.gameObject.transform;
                    }
                }
                if (gameObject.tag == "Dron")
                { 
                    gameObject.transform.parent.GetComponent<Destroy>().destroy();
                }
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
    }

    internal void restart()
    {
        health = initialHealth;
        actSlider();
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
    private void actSlider()
    {
        if (gameObject.name == "Player") slider.value = health;
    }
    public void lifeIncrease(float health_inc)
    {
        health += health_inc;
        health = Mathf.Min(health, max_health);
        actSlider();
    }
}
