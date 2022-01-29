using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SorgeProject.Util;

namespace SorgeProject.Object
{
    public class RegionBehaviour : MonoBehaviour, IDropable
    {
        [SerializeField] NATION_NAME m_name;

        public bool IsDropable(Draggable draggable)
        {
            if (draggable is InfomationBehaviour infomation)
            {
                if (!infomation.IsHand) return Controller.PlayerDataConroller.Instance.IsPurchasable(infomation);
                else return true;
            }
            return false;
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

        public void SendInfomation(InfomationBehaviour infomation)
        {
            Controller.RegionController.Instance.AddParameter(m_name, infomation.Power, infomation.Moral, infomation.Trust);
        }
    }
}
