using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public static Action OnStepForward;
    public static Action OnStep;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            transform.Translate(Vector3.forward);
            OnStepForward?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.back);
            OnStep?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Translate(Vector3.left);
            OnStep?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right);
            OnStep?.Invoke();
        }
    }
}
