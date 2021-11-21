using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public static Action OnSpawnPrefab;
    
    public GameObject MrSpherePrefab;
    public Transform SpawnPoint;

    private void OnTriggerStay(Collider other)
    {
        if (!MrSphereScript.MmeSphereExist)
        {
            Instantiate(MrSpherePrefab, SpawnPoint);
            OnSpawnPrefab?.Invoke();
            MrSphereScript.MmeSphereExist = true;
        }
        
    }
}
