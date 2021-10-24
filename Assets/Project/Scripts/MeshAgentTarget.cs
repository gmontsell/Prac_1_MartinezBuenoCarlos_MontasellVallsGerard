using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgentTarget : MonoBehaviour
{


    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform[] walkPoints;
    [SerializeField] private Transform target;
    private bool detected=false;
    private bool haveMove=true;
    private int idx = 0;

    private void Update()
    {
        if (haveMove) {
            if (!detected) agent.destination = walkPoints[idx].position;
            else agent.destination = target.position;
        }
    }

    public void changeWalkPoint(int walkPoint)
    {
        idx = walkPoint;
    }

    public bool isOnPoint()
    {
        return gameObject.transform.position.x == walkPoints[idx].position.x
               && gameObject.transform.position.z == walkPoints[idx].position.z;
    }

    public void nextPoint()
    {
        if (idx + 1 < walkPoints.Length) idx++;
        else idx = 0;
    }

    public void targetDetected()
    {
        detected = true;
    }
    public void enemyLost()
    {
        detected = false;
    }
    public void stopWalk()
    {
        haveMove = false;
    }
    public void continueFollowing()
    {
        haveMove = true;
    }
}
