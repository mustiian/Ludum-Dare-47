using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private List<CheckpointItem> CheckpointItems = new List<CheckpointItem>();

    public static CheckpointManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddCheckpointItem(CheckpointItem item)
    {
        CheckpointItems.Add(item);
    }

    public void SaveCheckpoint()
    {
        foreach (var item in CheckpointItems)
        {
            item.SaveCheckPoint();
        }
    }

    public void ResetToCheckpoint()
    {
        foreach (var item in CheckpointItems)
        {
            item.ResetToCheckpoint();
        }
    }

    public void RemoveItem(CheckpointItem item)
    {
        CheckpointItems.Remove(item);
    }
}
