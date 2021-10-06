using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    //[SerializeField] private GameObject bullet;
    //[SerializeField] private Transform weaponDoomy;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask shootLayerMask;
    [SerializeField] private float bulletDmg;


    [Header("Loading")]
    [SerializeField] private int loadedBullets = 0;
    [SerializeField] private int unloadedBullets = 0;
    [SerializeField] private int maxLoadedBullets = 10;
    [SerializeField] private KeyCode reoladKeyCode = KeyCode.R;

    [SerializeField] private Camera cam;
    [SerializeField] private UnityEvent<int, int> ammoChanged;

    [Header("Decal")]
    [SerializeField] private GameObject decal;
    [SerializeField] private float zOffset;
    [SerializeField] private DeaclePool deaclePool; 
    private void Start()
    {
        ammoChanged.Invoke(loadedBullets,unloadedBullets);
    }
    void Update()
    {
        if (Input.GetKeyDown(reoladKeyCode))reload();
        
        if (Input.GetMouseButtonUp(0))
        {
            if (loadedBullets > 0)
            {
                loadedBullets--;
                shootByRaycast();
            }
            else cannotShoot();

        }
        //if (Input.GetMouseButtonUp(2)) shooByInstantatiation();

    }

    void reload()
    {
        int loadedEmptyBullets = maxLoadedBullets - loadedBullets;
        int toLoad = Mathf.Min(unloadedBullets, loadedEmptyBullets);
        loadedBullets += toLoad;
        unloadedBullets -= toLoad;
        ammoChanged.Invoke(loadedBullets, unloadedBullets);


    }
    void cannotShoot()
    {
        //TODO CANNOT SHOT ANIMATION
        Debug.Log("no pots disparar");
    }
    //void shooByInstantatiation()
    //{
    //    GameObject currBull = Instantiate(bullet, weaponDoomy.position, weaponDoomy.rotation);
    //    currBull.GetComponent<Rigidbody>().velocity = weaponDoomy.forward * bulletSpeed;
    //}
       


    void shootByRaycast()
    {
        //Para caida de bala hacemos calculo del raycast modificando la velocidad màxima
        Ray r = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, maxDistance, shootLayerMask)) { 
        HealthSystem hs = hitInfo.transform.gameObject.GetComponent<HealthSystem>();
        if (hs != null)  hs.takeDamage(bulletDmg);
            //ADD deal
        deaclePool.activateObject(hitInfo.point + hitInfo.normal * zOffset, Quaternion.LookRotation(hitInfo.normal));
        //Instantiate(decal, hitInfo.point+hitInfo.normal*zOffset, Quaternion.LookRotation(hitInfo.normal));
        }
        ammoChanged.Invoke(loadedBullets, unloadedBullets);
    }
}
