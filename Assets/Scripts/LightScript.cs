using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public List<Light> lights;
    public Light backLight;

    public void HandleCarLight()
    {
        foreach(Light light in lights)
        {
            light.intensity = light.intensity == 0 ? 2 : 0;
        }
    }

    public void HandleBrakeLight()
    {
        backLight.intensity = backLight.intensity == 0 ? 2 : 0;
    }
   
}
