using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageManager;

public class StartSceneStage : Stage
{
    public float FadeTime = 2;

    public override bool ConditionToFinish()
    {
        return isFinished;
    }

    public override void InitStage()
    {
        FindObjectOfType<FaderController>().FadeOut(FadeTime);

        ExitStage();
    }

    public override void UpdateStage()
    {

    }
}
