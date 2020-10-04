using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointItem : MonoBehaviour
{
    private Stack<Vector2> checkpointPosition;

    private Rigidbody2D rigibody;

    // Start is called before the first frame update
    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();

        CheckpointManager.instance.AddCheckpointItem(this);

        SaveCheckPoint();
    }

    public void SaveCheckPoint()
    {
        checkpointPosition.Push (rigibody.position);
    }

    public void ResetToCheckpoint()
    {
        rigibody.position = checkpointPosition.Pop();
        rigibody.velocity = Vector2.zero;
        rigibody.angularVelocity = 0f;
    }

    private void OnDestroy()
    {
        CheckpointManager.instance.RemoveItem(this);
    }
}
