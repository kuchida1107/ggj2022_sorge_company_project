using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace SorgeProject.Util
{
    public class MasterDataLoaderFromSheet : MonoBehaviour, IDataLoader
    {
        [SerializeField] string sheet = "infomation_data";
        [SerializeField] string spreadsheetId = "1Uk4ie5rjKWpB8spBxnfa78-uN7V0VotIwf7E7uy3eYQ";
        const string prefix = "https://docs.google.com/spreadsheets/d/";
        const string suffix = "/gviz/tq?tqx=out:csv&sheet=";

        IEnumerator IDataLoader.LoadData<T>()
        {
            UnityWebRequest request = UnityWebRequest.Get(prefix + spreadsheetId + suffix + sheet);
            yield return request.SendWebRequest();

            if (request.isHttpError || request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                yield return CSVParser.Parse<T>(request.downloadHandler.text);
            }
        }
    }

    public interface IDataLoader
    {
        IEnumerator LoadData<T>() where T : ISerializableData, new();
    }

    public interface ISerializableData
    {
        void Set(string key, string value);
    }

    public static class CSVParser
    {
        public static IEnumerable<T> Parse<T>(string csvData) where T : ISerializableData, new()
        {
            var enumerator = csvData.Split('\n').Select(col => col.Split(',').Select(str => str.Trim('"'))).GetEnumerator();
            if (!enumerator.MoveNext())
            {
                return new T[0];
            }
            var keys = enumerator.Current;
            List<T> result = new List<T>();
            while (enumerator.MoveNext())
            {
                var instance = new T();
                var values = enumerator.Current;


                var keyValue = keys.Zip(values, (key, value) => (key, value));
                foreach (var (key, value) in keyValue)
                {
                    instance.Set(key, value);
                }
                result.Add(instance);

            }
            return result;
        }
    }
}