using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_shooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform weaponDoomy;
    [SerializeField] float bulletSpeed;

    private void OnEnable()
    {
        Debug.Log("Disparando");
        shooByInstantatiation();
        StartCoroutine(waiter());
    }
    public void shooByInstantatiation()
    {
      GameObject currBull = Instantiate(bullet, weaponDoomy.position, weaponDoomy.rotation);
      currBull.GetComponent<Rigidbody>().velocity = weaponDoomy.forward * bulletSpeed;
    }

    IEnumerator waiter()
    {
        Debug.Log("wait");
        yield return new WaitForSeconds(1);
        shooByInstantatiation();
        Debug.Log("Dispar");
        
    }
}
