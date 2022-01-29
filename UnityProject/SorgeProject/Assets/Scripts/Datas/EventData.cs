namespace SorgeProject.Data
{
    [System.Serializable]
    public class EventData : Util.ISerializableData
    {
        public int id;
        public string title;
        public int failed_power;
        public int failed_moral;
        public int success_power;
        public int success_moral;
        public string flavor;

        public void Set(string key, string value)
        {
            switch (key)
            {
                case "id":
                    id = int.Parse(value);
                    return;
                case "title":
                    title = value;
                    return;
                case "failed_power":
                    failed_power = int.Parse(value);
                    return;
                case "failed_moral":
                    failed_moral = int.Parse(value);
                    return;
                case "success_power":
                    success_power = int.Parse(value);
                    return;
                case "success_moral":
                    success_moral = int.Parse(value);
                    return;
                case "flavor":
                    flavor = value;
                    return;
            }
        }
    }
}
