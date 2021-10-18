using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] float max_shield = 100.0f;
    public float act_shield = 100.0f;
    [SerializeField] float prc_shield = 30.0f;
   
    public bool haveShield()
    {
        return act_shield > 0;
    }

    public float calculateDmg(float dmg)
    {
        float helth_dmg = (dmg * prc_shield / 100);
        act_shield -= dmg- helth_dmg;
        return helth_dmg;
    }

    internal void shieldIncrease(float shield_inc)
    {
        act_shield += shield_inc;
        act_shield = Mathf.Min(act_shield, max_shield);
    }
}
