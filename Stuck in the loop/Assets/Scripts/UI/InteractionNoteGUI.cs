using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InteractionNoteGUI : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private new Camera camera;

        private Canvas canvas;

        private void Awake()
        {
            canvas = GetComponentInParent<Canvas>();
        }

        public void ShowFor(GameObject target)
        {
            var renderer = target.GetComponentInChildren<Renderer>();
            var bounds = renderer.bounds;
            var max = bounds.max;
            var min = bounds.min;

            var screenMax = camera.WorldToScreenPoint(max);
            var screenMin = camera.WorldToScreenPoint(min);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                transform.parent as RectTransform,
                screenMax, 
                canvas.renderMode == RenderMode.ScreenSpaceOverlay 
                    ? null 
                    : canvas.worldCamera,
                out Vector2 localPoint
            );

            transform.localPosition = localPoint;
            
            animator.SetBool("show", true);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            IEnumerator Routine()
            {
                animator.SetBool("show", false);

                yield return null;

                // var transition = animator.GetBehaviour<>();
                // yield return new WaitForSeconds(transition.duration);
                // yield return new WaitForSeconds(transition.);
                
                gameObject.SetActive(false);
            }
            
            StartCoroutine(Routine());
        }
    }
}