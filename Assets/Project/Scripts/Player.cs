using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager1 gameManager;
    private void Start()
    {
        GetComponent<HealthSystem>().setDieFunction(
            died
            );
    }


    private void died()
    {
        gameManager.gameOver();
    }
}
