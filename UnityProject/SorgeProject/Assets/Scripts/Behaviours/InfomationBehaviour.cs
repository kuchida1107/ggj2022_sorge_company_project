using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using SorgeProject.Util;

using SorgeProject.Data;

namespace SorgeProject.Object
{
    public class InfomationBehaviour : Draggable
    {
        public float LifeTime { get; private set; }
        public int Cost { get; private set; }

        public override void OnChanged()
        {
            print("kawattayo");
        }

        public void SetData(InfoData data, float lifeTime)
        {
            LifeTime = lifeTime;

            //必ず直すこと
            Cost = 10;
        }
    }
}