using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageManager;
using UnityEngine.SceneManagement;

public class StartNextSceneStage : Stage
{
    public float FadeTime = 2f;

    private bool loadNextScene = false;

    private FaderController fader;

    public override bool ConditionToFinish()
    {
        return isFinished;
    }

    public override void InitStage()
    {
        FindObjectOfType<FaderController>().FadeIn(FadeTime);
        StartCoroutine(WaitToLoadNextScene(FadeTime));

        ExitStage();
    }

    public override void UpdateStage()
    {
        
    }

    private IEnumerator WaitToLoadNextScene(float time)
    {
        yield return new WaitForSeconds(FadeTime);

        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
