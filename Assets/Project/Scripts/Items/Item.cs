using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    public void consume (GameObject consumer)
    {
        Shooting shooting = consumer.GetComponent<Shooting>();
        HealthSystem hs = consumer.GetComponent<HealthSystem>();
        Shield shield = consumer.GetComponent<Shield>();
        if (shooting != null)
        {
            shooting.addBullets(itemData.ammo);
        }
        if (hs != null)
        {
            hs.lifeIncrease(itemData.health);
        }
        if (shield != null)
        {
            shield.shieldIncrease(itemData.shield);
        }
        Destroy(gameObject);
    }
    
}
