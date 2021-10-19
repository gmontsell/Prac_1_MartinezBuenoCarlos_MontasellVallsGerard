using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Transform initTransform;

    public void gameOver()
    {
        Restart();
    }

    public void Restart()
    {
        player.GetComponent<HealthSystem>().restart();
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = initTransform.position;
        player.transform.rotation = initTransform.rotation;
        player.GetComponent<CharacterController>().enabled = true;

    }
}
