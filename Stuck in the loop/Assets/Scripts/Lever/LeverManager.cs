using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class LeverManager : MonoBehaviour
{
    public LeverType Type;

    [HideInInspector]
    public CheckpointManager CheckpointManager;

    private void Start()
    {
        CheckpointManager = FindObjectOfType<CheckpointManager>();
    }

    public void ActivateLever()
    {
        if (Type == LeverType.Restorer)
            CheckpointManager.ResetToCheckpoint();
        else if (Type == LeverType.Saver)
            CheckpointManager.SaveCheckpoint();
    }
}

public enum LeverType { Saver, Restorer }
