using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SorgeProject.Util;
using SorgeProject.Data;
using SorgeProject.Object;

namespace SorgeProject.Controller
{
    public class InfomationController : MonoBehaviour, IController
    {
        [SerializeField] string sheetName = "infomation_data";
        List<InfoData> infoDatas;

        // 適当
        [SerializeField] float poptime = 10f;

        [SerializeField] float infoLifeTime = 20f;

        [SerializeField] RegionBehaviour[] regions;
        [SerializeField] InfomationBehaviour infomationPrefab;

        private IEnumerator DataLoad()
        {
            Debug.Log("データロード中", this);
            var gen = MasterDataLoaderFromSheet.LoadData<InfoData>(sheetName);
            yield return gen;
            var data = gen.Current as List<InfoData>;
            infoDatas = data;
            Debug.Log("データロード終了", this);
        }

        public void PlayUpdate() { }

        public void PlayStart()
        {
            StartCoroutine(PopUpdate());
        }

        void IController.Setup()
        {
            StartCoroutine(DataLoad());
        }

        public bool IsInitialized { get => infoDatas != null; }

        IEnumerator PopUpdate()
        {
            float timer = 0f;
            while(true)
            {
                timer += Time.deltaTime;
                if (timer > poptime)
                {
                    PopInfomation();
                    timer -= poptime;
                }
                yield return null;
            }
        }

        void PopInfomation()
        {
            var dataIdx = Random.Range(0, infoDatas.Count);
            var data = infoDatas[dataIdx];
            var regionIdx = Random.Range(0, regions.Length);
            var region = regions[regionIdx];

            var instance = Instantiate(infomationPrefab, region.transform);

            instance.SetData(data, infoLifeTime);
            regions[regionIdx].Pop<InfomationBehaviour>(instance);
        }
    }
}