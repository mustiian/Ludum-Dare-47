using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public GameObject[] Lights;


    public void ActivateLight()
    {
        foreach (var light in Lights)
        {
            Debug.Log(light.name);
        }
    }
}
