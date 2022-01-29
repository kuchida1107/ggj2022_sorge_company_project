using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestObject : MonoBehaviour
{
    SorgeProject.Util.IDataLoader loader;
    Text text;
    public void Start()
    {
        loader = GetComponent<SorgeProject.Util.IDataLoader>();
        text = GetComponent<Text>();
        StartCoroutine(LoadLog());
    }

    IEnumerator LoadLog()
    {
        var gen = loader.LoadData<SorgeProject.Data.InfoData>();
        yield return gen;
        var list = gen.Current as List<SorgeProject.Data.InfoData>;
        string str = "";
        foreach(var elm in list)
        {
            str += $"{elm.id}: {elm.text}\n";
        }
        text.text = str;
    }
}
