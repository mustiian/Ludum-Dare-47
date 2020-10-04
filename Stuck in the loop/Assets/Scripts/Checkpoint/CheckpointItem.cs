﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointItem : MonoBehaviour
{

    private Vector2 checkpointPosition;

    private Rigidbody2D rigibody;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();

        var manager = FindObjectOfType<CheckpointManager>();
        manager.AddCheckpointItem(this);
    }

    public void SaveCheckPoint()
    {
        checkpointPosition = rigibody.position;
    }

    public void ResetToCheckpoint()
    {
        rigibody.position = checkpointPosition;
        rigibody.velocity = Vector2.zero;
        rigibody.angularVelocity = 0f;
    }
}