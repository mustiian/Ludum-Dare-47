using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class LeverManager : MonoBehaviour
{
    public LightController[] Lights;
    public bool Activated = false;

    public void ActivateLight()
    {
        Activated = !Activated;

        foreach (var light in Lights)
        {
            light.ChangeLight();
        }
    }
}
