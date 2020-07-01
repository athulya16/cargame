using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(LightScript))]
public class CarControler : MonoBehaviour
{
    public InputManager inputManager;
    public LightScript lightScript;
    public List<WheelCollider> backWheels;
    public List<GameObject> frontWheels;
    public List<GameObject> wheels;
    public float torque = 20000f;
    public float maxAngle = 20f;
    public Transform cm;
    public Rigidbody rigidbody;
    public float brakePower;
    bool brakeLight = false;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        rigidbody = GetComponent<Rigidbody>();

        if(cm)
        {
            rigidbody.centerOfMass = cm.position;
        }
    }

    private void Update()
    {
        if(inputManager.lightInput)
        {
            lightScript.HandleCarLight();
        }
        if(inputManager.brake)
        {
            if (!brakeLight)
            {
                brakeLight = true;
                lightScript.HandleBrakeLight();
            }
        }
        else
        {
            if (brakeLight)
            {
                brakeLight = false;
                lightScript.HandleBrakeLight();
            }
        }
    }

    private void FixedUpdate()
    {
        foreach(WheelCollider wheel in backWheels)
        {
            if(inputManager.brake)
            {
                wheel.motorTorque = 0f;
                wheel.brakeTorque = brakePower * Time.deltaTime;
            }
            else
            {
                wheel.motorTorque = torque * Time.deltaTime * inputManager.throttle;
                wheel.brakeTorque = 0f;
            }
        }

        foreach (GameObject wheel in frontWheels)
        {
            wheel.GetComponent<WheelCollider>().steerAngle = maxAngle * inputManager.steer;
            wheel.transform.localEulerAngles = new Vector3(0f, inputManager.steer * maxAngle, 0f);
        }

        foreach(GameObject wheelMesh in wheels)
        {
            wheelMesh.transform.Rotate( rigidbody.velocity.magnitude * (transform.InverseTransformDirection(rigidbody.velocity).z >=0 ? 1 : -1) / (2 * Mathf.PI * 0.23f),0f,0f);
        }
    }
}
