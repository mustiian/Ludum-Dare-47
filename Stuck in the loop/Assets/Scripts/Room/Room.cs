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
        [SerializeField] private Transform fade;

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
                floor.size = size;
                floor.transform.localPosition = Vector3.zero;
            }

            if (fade != null)
            {
                fade.transform.localPosition = Vector3.zero;
                fade.transform.localScale = new Vector3(size.x, size.y, 1f);
                fade.transform.localRotation = Quaternion.identity;
            }
        }

        private void SynchornizeWall(int index, Vector3 up)
        {
            var wall = walls[index];
            wall.transform.parent = transform;
            wall.transform.localScale = Vector3.one;
            wall.Renderer.size = new Vector2(wallThickness, (Mathf.Abs(up.x) == 0 ? size.x : size.y) + wallThickness);
            wall.transform.localPosition = new Vector2(size.x * 0.5f, size.y * 0.5f) * up;
            wall.transform.right = up;
            wall.Synchronize();
        }
    }
}

