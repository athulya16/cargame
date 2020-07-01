using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject car;
    public float gap = 5f;
    public float height = 2f;
    public float offset = 0.5f;

    private int mode = 0;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            mode = (mode + 1) % 2;
        }

        switch(mode)
        {
            case 1:
                transform.position = car.transform.position + car.transform.TransformDirection(new Vector3(0f, height, -gap));
                transform.LookAt(car.transform);
                break;
            default:
                transform.position = Vector3.Lerp(transform.position, car.transform.position + car.transform.TransformDirection(new Vector3(0f, height, -gap)), offset * Time.deltaTime);
                transform.LookAt(car.transform);
                break;

        }
    }
}
