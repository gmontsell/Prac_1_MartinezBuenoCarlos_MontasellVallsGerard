using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Transform initTransform;
    [SerializeField] private List<Transform> chekPoints;

    public void gameOver(int idx)
    {
            Restart(idx);
       
    }

    public void Restart(int idx)
    {
        player.GetComponent<HealthSystem>().restart();
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = chekPoints[idx].position;
        player.transform.rotation = chekPoints[idx].rotation;
        player.GetComponent<CharacterController>().enabled = true;

    }
}
