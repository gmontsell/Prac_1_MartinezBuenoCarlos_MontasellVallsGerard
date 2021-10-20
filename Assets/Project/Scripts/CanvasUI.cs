using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] private Text ammo;
    [SerializeField] private Text points;

    public void UpdateAmmo(int loadedBullets, int unloadedBullets)
    {
        ammo.text= loadedBullets +"/"+ unloadedBullets;
    }

    public void UpdatePoints(int point)
    {
        points.text = "Points: " + point;
    }
}
