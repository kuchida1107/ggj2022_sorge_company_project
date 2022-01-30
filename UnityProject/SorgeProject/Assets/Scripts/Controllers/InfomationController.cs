using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using SorgeProject.Util;
using SorgeProject.Data;
using SorgeProject.Object;
using System.Linq;

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

        [SerializeField] SpritePair[] spriteKeys;

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
            Instance = this;
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

            instance.SetData(data, infoLifeTime, region.Name);
            regions[regionIdx].Pop<InfomationBehaviour>(instance);
        }

        public static Sprite GetCardSpriteByType(InfomationBehaviour infomation)
        {
            int profit = (infomation.SellCost - infomation.Cost) >> 1; //価格の補正　すごく適当
            int power = infomation.Power;
            int moral = infomation.Moral;
            int trust = infomation.Trust;
            int event_id = infomation.EventId;

            InfomationHighest type;
            if (event_id != 0) type = InfomationHighest.EVENT;
            else if (profit > power && profit > moral && profit > trust) type = InfomationHighest.PROFIT;
            else if (power > moral && power > trust) type = InfomationHighest.POWER;
            else if (moral > trust) type = InfomationHighest.MORAL;
            else type = InfomationHighest.TRUST;

            var match = Instance.spriteKeys.FirstOrDefault(keyvalue => keyvalue.highest == type).sprite;
            return match;
        }

        public static InfomationController Instance { get; private set; }

        private enum InfomationHighest
        {
            PROFIT,
            POWER,
            MORAL,
            TRUST,
            EVENT,
        }

        [System.Serializable]
        private struct SpritePair
        {
            public InfomationHighest highest;
            public Sprite sprite;
        }
    }
}