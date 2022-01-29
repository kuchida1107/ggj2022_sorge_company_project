using UnityEngine;
using UnityEngine.EventSystems;

namespace SorgeProject.Util
{
    public interface IDropable
    {
        bool IsDropable(Draggable draggable);
        void OnDrop(Draggable draggable);
        void OnExit(Draggable draggable);
    }

    [RequireComponent(typeof(CanvasGroup))]
    public abstract class Draggable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        Vector3 originPos;
        CanvasGroup canvasGroup;
        IDropable parent;

        private void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            parent = GetComponentInParent<IDropable>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (parent != null) parent.OnExit(this);
            canvasGroup.blocksRaycasts = false;
            originPos = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = true;
            var dropObject = eventData.pointerEnter;
            var drop = dropObject?.GetComponent<IDropable>();

            if (drop == null || !drop.IsDropable(this))
            {
                transform.position = originPos;
                if (parent != null) parent.OnDrop(this);
                return;
            }

            parent = drop;
            drop.OnDrop(this);
        }

        public abstract void OnChanged();
    }
}
