using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootingGalley : MonoBehaviour
{
    [SerializeField] private Text textPoints;
    [SerializeField] private Text textLevel;
    //  [SerializeField] private GameObject targets;
    [SerializeField] private CanvasUI cs;
    public void Start()
    {
        textPoints.gameObject.SetActive(false);
    }
     public void Update()
    {
       if (Input.GetKeyDown(KeyCode.Z) )
        {
            //restart();
            //Mirar si el child tiene objetos
            //Si no tiene dar opcion de reset o de pasar de nivel
            //Si tiene no hacer nada 

        }
        if (cs.getPoints() == 50 && textPoints.isActiveAndEnabled)
        {
            nextLevel();
        }
        
    }
    //private void restart()
    //{

    //    Debug.Log(targets.GetComponentsInParent<GameObject>());
    //}

    private void nextLevel()
    {
        textLevel.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Q)) { SceneManager.LoadScene("SciFi_Scene"); }

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
