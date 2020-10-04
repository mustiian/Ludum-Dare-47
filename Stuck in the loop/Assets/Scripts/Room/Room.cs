#pragma warning disable CS0649

using System;
using UnityEngine;

namespace Game
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Vector2 size;
        [SerializeField] private float wallThickness;
        [SerializeField] private Wall[] walls;
        [SerializeField] private SpriteRenderer floor;

        private void OnValidate()
        {
            Synchornize();
        }

        [ContextMenu("Synchronize")]
        private void Synchornize()
        {
            if (walls.Length == 4)
            {
                SynchornizeWall(0,  transform.up);
                SynchornizeWall(1,  transform.right);
                SynchornizeWall(2, -transform.up);
                SynchornizeWall(3, -transform.right);
            }

            if (floor != null)
            {
                floor.transform.parent = transform;
                floor.transform.localScale = size;
                floor.transform.localPosition = Vector3.zero;
            }
        }

        private void SynchornizeWall(int index, Vector3 up)
        {
            var wall = walls[index];
            wall.transform.parent = transform;
            wall.transform.localScale = new Vector2((Mathf.Abs(up.x) == 0 ? size.x : size.y) + wallThickness, wallThickness);
            wall.transform.localPosition = new Vector2(size.x * 0.5f, size.y * 0.5f) * up;
            wall.transform.up = up;
            wall.Synchronize();
        }
    }
}

