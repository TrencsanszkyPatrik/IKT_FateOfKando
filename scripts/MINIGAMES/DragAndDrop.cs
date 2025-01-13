using UnityEngine;
using UnityEngine.EventSystems;

namespace jatek
{
    public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Canvas canvas;

        private Vector2 originalPosition;
        private bool isPlaced = false;

        public GameObject targetArea;
        private Roller rollerScript;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponentInParent<Canvas>();
        }

        void Start()
        {
            rollerScript = FindObjectOfType<Roller>(); 
            originalPosition = rectTransform.anchoredPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (isPlaced || rollerScript == null || !rollerScript.IsPaperAvailable()) return;

            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0.6f;
                canvasGroup.blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (isPlaced || rollerScript == null || !rollerScript.IsPaperAvailable()) return;

            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
            }

            if (targetArea != null && RectTransformUtility.RectangleContainsScreenPoint(targetArea.GetComponent<RectTransform>(), Input.mousePosition))
            {
                isPlaced = true; 
                rectTransform.rotation = Quaternion.Euler(rectTransform.rotation.eulerAngles.x, rectTransform.rotation.eulerAngles.y, 0f);
                rectTransform.anchoredPosition = targetArea.GetComponent<RectTransform>().anchoredPosition;
            }
        }

        public bool IsPlaced()
        {
            return isPlaced;
        }
    }
}
