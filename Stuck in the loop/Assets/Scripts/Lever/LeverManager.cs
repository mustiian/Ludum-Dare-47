using UnityEngine;
using System;

public class LeverManager : MonoBehaviour
{
    public LeverType Type;

    [HideInInspector]
    public CheckpointManager CheckpointManager;

    public Action OnActivationLever;

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

        OnActivationLever?.Invoke();
    }
}

public enum LeverType { Saver, Restorer }
