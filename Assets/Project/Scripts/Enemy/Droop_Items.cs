using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droop_Items : MonoBehaviour
{
   [SerializeField] List<GameObject> item =new List<GameObject>();
    [SerializeField] float prob_drop = 30.0f;
    private void OnDestroy()
    {
        int random = Random.Range(0,item.Count);
        int prob = Random.Range(0, 100);

        if (prob<prob_drop) {
            Instantiate(item[random], transform.position, transform.rotation);
        }

    }
}
