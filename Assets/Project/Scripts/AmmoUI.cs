using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private Text text;

    public void updateAmmo(int loadedBullets, int unloadedBullets)
    {
        text.text= loadedBullets +"/"+ unloadedBullets;
    }
}
