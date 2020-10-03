using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class LeverManager : MonoBehaviour
{
    public LightController[] Lights;

    public void ActivateLight()
    {
        foreach (var light in Lights)
        {
            light.ChangeLight();
        }
    }
}
