using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageManager;

public class CorrectPlatformsStage : Stage
{
    [System.Serializable]
    public struct PlatformStatus
    {
        public PlatformTriger platformTrigger;
        public bool Status;
    }

    public PlatformStatus[] CheckPlatforms;

    public override bool ConditionToFinish()
    {
        isFinished = true;

        foreach (var platform in CheckPlatforms)
        {
            if (platform.platformTrigger.activated != platform.Status)
                isFinished = false;
        }

        return isFinished;
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
