using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    public ColorType.Color LightColor;

    private Light2D light2D;
    private float defaultIntensity;

    // Start is called before the first frame update
    void Start()
    {
        light2D = GetComponent<Light2D>();
        defaultIntensity = light2D.intensity;
    }

    public void ChangeLight()
    {
        light2D.intensity = light2D.intensity == 0 ? defaultIntensity : 0;
    }
}
