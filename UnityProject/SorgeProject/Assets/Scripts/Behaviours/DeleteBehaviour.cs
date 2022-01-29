using SorgeProject.Object;
using SorgeProject.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBehaviour : MonoBehaviour, IDropable
{
    public bool IsDropable(Draggable draggable)
    {
        if (draggable is InfomationBehaviour infomation)
        {
            return infomation.IsHand;
        }
        return false;
    }

    public void OnDrop(Draggable draggable)
    {
        var infomation = draggable as InfomationBehaviour;
        infomation.Destroy();
    }

    public void OnExit(Draggable draggable)
    {
        Debug.Log("???");
    }
}
