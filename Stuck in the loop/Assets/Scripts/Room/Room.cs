#pragma warning disable CS0649

using UnityEngine;

namespace Game
{
    public class Room : MonoBehaviour
    {
        [SerializeField] private Vector2 size;
        [SerializeField] private float wallThickness;
        [SerializeField] private SpriteRenderer[] walls;
        [SerializeField] private SpriteRenderer floor;
        
        private void OnValidate()
        {
            if (walls.Length == 4)
            {
                UpdateWall(0,  transform.up);
                UpdateWall(1,  transform.right);
                UpdateWall(2, -transform.up);
                UpdateWall(3, -transform.right);
            }

            if (floor != null)
            {
                floor.transform.parent = transform;
                floor.transform.localScale = size;
                floor.transform.localPosition = Vector3.zero;
            }
        }

        private void UpdateWall(int index, Vector3 up)
        {
            var wall = walls[index];
            wall.transform.parent = transform;
            wall.transform.localScale = new Vector2(
                Mathf.Abs(up.x) == 0 ? size.x + wallThickness : wallThickness, 
                Mathf.Abs(up.y) == 0 ? size.y + wallThickness : wallThickness
            );
            wall.transform.localPosition = new Vector2(size.x * 0.5f, size.y * 0.5f) * up;
            wall.transform.up = Vector3.up;
        }
    }
}

