using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SorgeProject.Util;

namespace SorgeProject.Object
{
    public class RegionBehaviour : MonoBehaviour, IDropable
    {
        public bool IsDropable(Draggable draggable)
        {
            return true;
        }

        public void OnDrop(Draggable draggable)
        {
            draggable.transform.SetParent(transform);
        }

        public void OnExit(Draggable draggable)
        {
            draggable.transform.SetParent(transform.parent);
        }
    }
}
