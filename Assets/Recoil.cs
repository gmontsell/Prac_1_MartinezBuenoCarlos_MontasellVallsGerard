using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{

    [Header("Recoil")]
    [SerializeField] private float rang_Recoil = 0.5f;
    [SerializeField] FPSController_0 contr_0;

    private void Start()
    {
        contr_0 = gameObject.GetComponent<FPSController_0>();
    }
    public void recoilShooting()
    {
        //X yaw y Y pitch
        float maxRecoil_x = Random.Range(0, rang_Recoil);
        float maxRecoil_y = Random.Range(-rang_Recoil, rang_Recoil);
        Debug.Log(maxRecoil_x);
        Debug.Log(contr_0);
        contr_0.modifMYaw(maxRecoil_x);
        contr_0.modifMPitch(maxRecoil_y);

    }
}
