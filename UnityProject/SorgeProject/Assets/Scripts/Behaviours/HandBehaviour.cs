using UnityEngine;

using SorgeProject.Util;
using SorgeProject.Controller;

namespace SorgeProject.Object
{
    public class HandBehaviour : MonoBehaviour, IDropable
    {
        public PlayerDataConroller Controller { private get; set; }

        // 仮
        public bool IsDropable(Draggable draggable)
        {
            if (draggable is InfomationBehaviour infomation)
            {
                if (Controller.IsPurchasable(infomation)) return true;
            }
            return false;
        }

        public void OnDrop(Draggable draggable)
        {
            SetPosition(draggable);
            Controller.Purchase(draggable as InfomationBehaviour);
        }

        public void OnExit(Draggable draggable)
        {
            draggable.transform.SetParent(transform.parent);
        }

        public void SetPosition(Draggable draggable)
        {
            draggable.transform.SetParent(transform);
            (draggable.transform as RectTransform).anchoredPosition = Vector3.zero;
        }
    }
}
