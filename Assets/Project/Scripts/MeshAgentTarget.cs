using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeshAgentTarget : MonoBehaviour
{


    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform target;

    private void Update()
    {
        agent.destination = target.position;
    }

}
