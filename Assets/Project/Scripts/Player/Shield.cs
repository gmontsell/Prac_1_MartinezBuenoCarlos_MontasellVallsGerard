using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    [SerializeField] float max_shield = 100.0f;
    public float act_shield = 100.0f;
    [SerializeField] float prc_shield = 30.0f;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider.value = act_shield;
    }
    public bool haveShield()
    {
        return act_shield > 0;
    }

    public float calculateDmg(float dmg)
    {
        float helth_dmg = (dmg * prc_shield / 100);
        act_shield -= dmg- helth_dmg;
        slider.value = act_shield;
        return helth_dmg;
    }

    internal void shieldIncrease(float shield_inc)
    {
        act_shield += shield_inc;
        act_shield = Mathf.Min(act_shield, max_shield);
        slider.value = act_shield;
    }
}
