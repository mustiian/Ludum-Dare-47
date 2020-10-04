
using UnityEngine;

namespace Game
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private float doorWidth;

        // private string WallColliderNamePart => $"{name} Collider";
        
        private void Start()
        {
            Synchronize();
        }

        [ContextMenu("Synchronize")]
        public void Synchronize()
        {
            var doors = GetComponentsInChildren<Door>();

            // foreach (var box in GetComponentsInChildren<Collider2D>())
            // {
            //     if (box.name.Contains(WallColliderNamePart)) 
            //         DestroyImmediate(box.gameObject);
            // }
            //
            // var localStart = new Vector3(-1f, 0f, 0f);
            // var localEnd   = new Vector3( 1f, 0f, 0f);
            var doorLocalScale = new Vector3(doorWidth / transform.lossyScale.x, 1f, 1f);
            //
            // int index = 0;
            //
            // var currentWallCollider = new GameObject($"{WallColliderNamePart} ({index++})")
            //     .AddComponent<BoxCollider2D>();
            // currentWallCollider.transform.parent = transform;
            // currentWallCollider.transform.localPosition = new Vector3(0.5f, 0f, 0f);
            // currentWallCollider.transform.localScale = new Vector3(1f, 1f, 1f);
            //
            foreach (var door in doors)
            {
                door.transform.parent = transform;
                door.transform.localScale = doorLocalScale;
                door.transform.localRotation = Quaternion.identity;
                //
                // var doorLocalStart = door.transform.localPosition + new Vector3(-doorLocalScale.x * 0.5f, 0f, 0f);
                // var doorLocalEnd   = door.transform.localPosition + new Vector3( doorLocalScale.x * 0.5f, 0f, 0f);
                //
                // currentWallCollider.transform.localRotation = Quaternion.identity;
                // currentWallCollider.transform.localPosition = new Vector3((localStart.x + doorLocalStart.x) * 0.5f, 0f, 0f);
                // currentWallCollider.transform.localScale = new Vector3(Mathf.Abs(localStart.x - doorLocalStart.x) * 0.5f, 1f, 1f);
                //
                // var nextWallCollider = new GameObject($"{WallColliderNamePart} ({index++})").AddComponent<BoxCollider2D>();
                //
                // nextWallCollider.transform.parent = transform;
                // nextWallCollider.transform.localRotation = Quaternion.identity;
                // nextWallCollider.transform.localPosition = new Vector3((doorLocalEnd.x + localEnd.x) * 0.5f, 0f, 0f);
                // nextWallCollider.transform.localScale = new Vector3(Mathf.Abs(doorLocalEnd.x - localEnd.x) * 0.5f, 1f, 1f);
                //
                // currentWallCollider = nextWallCollider;
            }
        }
    }
}