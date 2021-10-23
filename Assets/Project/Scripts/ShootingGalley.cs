using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingGalley : MonoBehaviour
{
    [SerializeField] private Text textPoints;
    [SerializeField] private GameObject targets;

    public void Start()
    {
        textPoints.gameObject.SetActive(false);
    }

    private void restart()
    {
        
        if (Input.GetKeyDown(KeyCode.Z)&& targets.GetComponentsInChildren<GameObject>() == null)
        {
            //Mirar si el child tiene objetos
            //Si no tiene dar opcion de reset o de pasar de nivel
            //Si tiene no hacer nada 

        }
        else
        {

        }
    }

  



    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.GetComponent<Player>())
        {
            
            textPoints.gameObject.SetActive(true);
           
        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            
            textPoints.gameObject.SetActive(false);

        }
    }
}
