using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SorgeProject.Util;

namespace SorgeProject.Object
{
    public class RegionBehaviour : MonoBehaviour, IDropable
    {
        //仮
        public bool IsDropable(Draggable draggable)
        {
            return true;
        }

        public void OnDrop(Draggable draggable)
        {
            SetPosition(draggable);
        }

        public void OnExit(Draggable draggable)
        {
            draggable.transform.SetParent(transform.parent);
        }

        public void Pop<T>(Draggable draggable) where T : Draggable
        {
            SetPosition(draggable);
            draggable.Initialize(this);
        }

        public void SetPosition(Draggable draggable)
        {
            draggable.transform.SetParent(transform);
            (draggable.transform as RectTransform).anchoredPosition = Vector3.zero;
        }
    }
}
