using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using SorgeProject.Util;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using SorgeProject.Data;

namespace SorgeProject.Object
{
    public class InfomationBehaviour : Draggable
    {
        [SerializeField]
        Image LifeSpanMeterImage = null;
        float FadeAwayTime = 1.0f;
        CanvasGroup InformationCanvasGroup;

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

        private void Awake()
        {
            if (LifeSpanMeterImage == null)
            {
                EditorUtility.DisplayDialog("Null Error", "Set Meter UI variables", "OK");
            }

            InformationCanvasGroup = GetComponent<CanvasGroup>();

            if (InformationCanvasGroup == null)
            {
                EditorUtility.DisplayDialog("Null Error", "Canvas Group not found", "OK");
            }
        }

        private void Start()
        {
            if (LifeSpanMeterImage)
            {
                LifeSpanMeterImage.fillAmount = 1f;
                StartCoroutine(LifeSpan(LifeSpanMeterImage, LifeTime));
            }
        }

        public IEnumerator LifeSpan(Image fillImage, float lifeTime)
        {
            if (fillImage == null)
                yield break;

            float startTime = Time.time;
            float time = lifeTime;
            float value = 0;

            while (Time.time - startTime < lifeTime)
            {
                time -= Time.deltaTime;
                value = time / lifeTime;
                fillImage.fillAmount = value;
                yield return null;
            }

            if (InformationCanvasGroup)
            {
                InformationCanvasGroup.interactable = false;
                InformationCanvasGroup.blocksRaycasts = false;
                StartCoroutine(FadeAwayAndDestroy(InformationCanvasGroup, FadeAwayTime));
            }
        }

        public IEnumerator FadeAwayAndDestroy(CanvasGroup canvasGroup, float lifeTime)
        {
            if (canvasGroup == null)
                yield break;

            float startTime = Time.time;
            float time = lifeTime;
            float value = 0;

            while (Time.time - startTime < lifeTime)
            {
                time -= Time.deltaTime;
                value = time / lifeTime;
                canvasGroup.alpha = value;
                yield return null;
            }

            Destroy(this);
        }
    }
}