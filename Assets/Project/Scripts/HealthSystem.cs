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
    
    [SerializeField] CanvasUI ui;
    

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
        if ( health<=0 && gameObject.tag == "Player"  || Input.GetKeyDown(KeyCode.K) && gameObject.tag=="Player")
            die();
    }


    public void takeDamage(float value)
    {
        if (gameObject.tag == "Dron")
        {
            gameObject.transform.parent.GetComponent<Enemy>().startHit();
        }
        health -= calculateDmg(value);
        actSlider();
        if (health <= 0.0f && gameObject.tag != "Player")
        {
            Transform[] allChildren = GetComponentsInChildren<Transform>();
            bool haveDecal = false;
            foreach (Transform child in allChildren)
            {
                if (child.gameObject.tag == "Target") {ui.UpdatePoints(10);}
                else if (child.gameObject.tag == "ExplosiveBarrel") { ui.UpdatePoints(5); }
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
                    gameObject.transform.parent.GetComponent<Enemy>().startDie();
                }
               else  Destroy(gameObject);
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
