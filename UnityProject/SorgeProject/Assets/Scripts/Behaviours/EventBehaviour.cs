using UnityEngine;

using SorgeProject.Util;
using UnityEngine.UI;
using System;
using System.Collections;

namespace SorgeProject.Object
{
    public class EventBehaviour : MonoBehaviour
    {
        [SerializeField] Text title;
        [SerializeField] Text flavor;
        [SerializeField] Text vlaueText;
        [SerializeField] float fadeTime = 0.5f;

        CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
        }

        public void SetData(string titleStr, string flavorStr)
        {
            title.text = titleStr;
            flavor.text = flavorStr;
        }

        internal void Pop()
        {
            StartCoroutine(FadeAndCallback(0f, 1f, null));
        }

        internal void Destroy()
        {
            StartCoroutine(FadeAndCallback(1f, 0f, () =>
            {
                GameObject.Destroy(gameObject);
            }));
        }

        private IEnumerator FadeAndCallback(float src, float dst, System.Action Action)
        {
            float timer = fadeTime;
            while(timer > 0)
            {
                canvasGroup.alpha = Mathf.Lerp(src, dst, 1f - timer / fadeTime);
                timer -= Time.deltaTime;
                yield return null;
            }
            canvasGroup.alpha = dst;
            Action?.Invoke();
        }
    }
}
