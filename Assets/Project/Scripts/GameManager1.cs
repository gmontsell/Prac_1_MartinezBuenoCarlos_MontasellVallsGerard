using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private List<Transform> chekPoints;
    private int last_chekPoint;

    private void Start()
    {
        setLastCheckpoint(0);
    }
    public void gameOver()
    {
            Restart();
    }

    public void Restart()
    {
        player.GetComponent<HealthSystem>().restart();
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = chekPoints[last_chekPoint].position;
        player.transform.rotation = chekPoints[last_chekPoint].rotation;
        player.GetComponent<CharacterController>().enabled = true;

    }
    public void setLastCheckpoint(int chekPoint)
    {
        chekPoints[last_chekPoint].gameObject.GetComponent<CheckPoint>().desactivateChekPoint();
        last_chekPoint = chekPoint;
        chekPoints[last_chekPoint].gameObject.GetComponent<CheckPoint>().activateChekPoint();
    }
}
