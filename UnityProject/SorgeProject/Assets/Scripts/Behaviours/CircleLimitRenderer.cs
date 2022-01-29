using UnityEngine;
using UnityEngine.UI;

namespace SorgeProject.Object
{
    public class CircleLimitRenderer : MonoBehaviour
    {
        [SerializeField]
        Image LifeSpanMeterImage = null;

        private void Start()
        {
            if (LifeSpanMeterImage)
            {
                LifeSpanMeterImage.fillAmount = 1f;
            }
        }

        public void SetValue(float amount)
        {
            LifeSpanMeterImage.fillAmount = amount;
        }

        public void Fade()
        {
            LifeSpanMeterImage?.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}