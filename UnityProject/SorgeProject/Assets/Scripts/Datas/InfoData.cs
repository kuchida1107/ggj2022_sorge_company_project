using UnityEngine;

namespace SorgeProject.Data
{
    [System.Serializable]
    public class InfoData : Util.ISerializableData
    {
        public int id;

        public void Set(string key, string value)
        {
            switch (key)
            {
                case "id":
                    id = int.Parse(value);
                    return;
            }
        }
    }
}
