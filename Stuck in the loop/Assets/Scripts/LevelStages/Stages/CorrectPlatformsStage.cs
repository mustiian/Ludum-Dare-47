using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageManager;

public class CorrectPlatformsStage : Stage
{
    //[System.Serializable]
    //public struct PlatformStatus
    //{
    //    public PlatformTriger platformTrigger;
    //    public bool Status;
    //}

    public PlatformTriger[] CheckPlatforms;

    public override bool ConditionToFinish()
    {
        foreach (var platform in CheckPlatforms)
        {
            if (platform.activated != true)
                return false;
        }

        return true;
    }

    private void Start()
    {
        CheckPlatforms = FindObjectsOfType<PlatformTriger>();
    }

    public override void InitStage()
    {
        
    }

    public override void UpdateStage()
    {
        if (ConditionToFinish())
            ExitStage();
    }
}
