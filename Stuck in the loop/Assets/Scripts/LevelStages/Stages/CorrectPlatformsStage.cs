using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageManager;

public class CorrectPlatformsStage : Stage
{
    private PlatformTriger[] CheckPlatforms;

    public override bool ConditionToFinish()
    {
        foreach (var platform in CheckPlatforms)
        {
            Debug.Log(platform.activated + " " + platform.gameObject.name);

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
        if (ConditionToFinish() || isFinished)
            ExitStage();
    }
}
