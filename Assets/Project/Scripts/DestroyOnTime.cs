using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTime : MonoBehaviour
{
    public float m_DestroyOnTime = 3.0f;
    [SerializeField] GameObject decalepool;
    private void Awake()
    {
        decalepool = GameObject.Find("DecalPool");
    }
    private void OnEnable()
    {
        StartCoroutine(DestroyOnTimeFn());
    }
    IEnumerator DestroyOnTimeFn()
    {
        yield return new WaitForSeconds(m_DestroyOnTime);
        gameObject.transform.parent = decalepool.transform;
        gameObject.SetActive(false);
    }
}
