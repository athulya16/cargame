using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public bool lightInput;
    public bool brake;

    void Update()
    {
        throttle = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");

        lightInput = Input.GetKeyDown(KeyCode.L);
        brake = Input.GetKeyDown(KeyCode.Space);
    }
}
