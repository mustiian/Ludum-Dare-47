using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StageManager;
using UnityEngine.SceneManagement;
using Game;
using UnityEngine.Experimental.Rendering.Universal;

public class StartNextSceneStage : Stage
{
    public float FadeTime = 2f;

    public override bool ConditionToFinish()
    {
        return isFinished;
    }

    public override void InitStage()
    {
        foreach (var door in FindObjectsOfType<Door>())
        {
            door.GetComponentInChildren<BoxTrigger2D>().OnEnter += EnterTriggerEvent;
            door.GetComponentInChildren<Light2D>().enabled = true;
        }
    }

    public void EnterTriggerEvent(Collider2D collider)
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
