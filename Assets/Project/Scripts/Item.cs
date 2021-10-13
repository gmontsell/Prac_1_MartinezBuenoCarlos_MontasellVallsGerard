using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    public void consume (GameObject consumer)
    {
        Shooting sh = consumer.GetComponent<Shooting>();
        if (sh != null)
        {
            sh.addBullets(itemData.ammo);
        }
        Destroy(gameObject);
    }
    
}
