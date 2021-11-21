using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrSphereScript : MonoBehaviour
{
    public static bool MmeSphereExist;
    
    private void OnDestroy()
    {
        MmeSphereExist = false;
    }
}
