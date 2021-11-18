using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour
{
    public static Action<Vector3> OnPlayerDestroy;
    public static Action OnSphereDestroy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerDestroy?.Invoke(other.transform.position);
        }
        else
        {
            OnSphereDestroy?.Invoke();
        }
        Destroy(other.gameObject);
    }
}
