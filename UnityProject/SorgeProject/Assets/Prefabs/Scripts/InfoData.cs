using UnityEngine;

namespace SorgeProject.Data
{
    public class InfoData : ScriptableObject, Util.ISerializableData
    {
        public int id;
        public string text;

        public void Set(string key, string value)
        {
            switch (key)
            {
                case "text":
                    text = value;
                    return;
                case "id":
                    id = int.Parse(value);
                    return;
            }
        }
    }
}
