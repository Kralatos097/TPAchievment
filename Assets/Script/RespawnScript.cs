using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public static Action<Vector3> OnPlayerRespawn;
    
    public GameObject PlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        DeathZoneScript.OnPlayerDestroy += delegate(Vector3 vector3)
        {
            Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
            OnPlayerRespawn?.Invoke(transform.position);
        };
    }
}
