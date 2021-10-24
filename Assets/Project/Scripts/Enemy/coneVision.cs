using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coneVision : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float max_angle = 80;
    [SerializeField] float distance = 10;
    [SerializeField] LayerMask layerMask;
    public bool targetLocated = false;
    void Update()
    {
        RaycastHit info;
        if(Physics.Raycast(transform.position, player.position - transform.position, out info, distance, layerMask)){
            if (info.transform.CompareTag("Player"))
            {
                Vector3 _direction = player.position - transform.position;
                _direction.Normalize();
                float angle = Vector3.Angle(transform.forward, _direction);
                if (angle <= max_angle)
                {
                    targetLocated = true;
                }
                else targetLocated = false;
            }
        }
        
    }
    public bool isTargetLocated()
    {
        return targetLocated;
    }
}
