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
        Instantiate(MrSpherePrefab, SpawnPoint);
        OnSpawnPrefab?.Invoke();
    }
}
