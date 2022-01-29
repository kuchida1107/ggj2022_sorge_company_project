using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public enum NATION_NAME
{
    ALPHA,
    BETA,
    NONE,
}

public class NationMeterController : MonoBehaviour
{

    [SerializeField]
    Slider alphaPowerSlider, betaPowerSlider, alphaMoralSlider, betaMoralSlider;

    [SerializeField]
    Image alphaTrustMeter, betaTrustMeter;

    [SerializeField]
    Sprite[] trustMeterSprites = new Sprite[5];

    const float TRUST_MIN = 0;
    const float TRUST_MAX = 100;

    public enum METER_TYPE
    {
        POWER,
        MORAL,
        TRUST,
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (alphaMoralSlider && betaMoralSlider && alphaPowerSlider && betaPowerSlider && alphaTrustMeter && betaTrustMeter)
        {
            alphaPowerSlider.minValue = betaPowerSlider.minValue = alphaMoralSlider.minValue = betaMoralSlider.minValue = 0f;
            alphaPowerSlider.maxValue = betaPowerSlider.maxValue = alphaMoralSlider.maxValue = betaMoralSlider.maxValue = 100f;
        }
        else
        {
#if UNITY_EDITOR
            EditorUtility.DisplayDialog("Null Error", "Set Meter UI variables", "OK");
#endif
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMeterValue(METER_TYPE eType, NATION_NAME eNation, float value)
    {
        switch(eType)
        {
            case METER_TYPE.MORAL:
                switch(eNation)
                {
                    case NATION_NAME.ALPHA:
                        SetSliderValue(alphaMoralSlider, value);
                        break;
                    case NATION_NAME.BETA:
                        SetSliderValue(betaMoralSlider, value);
                        break;
                }
                break;
            case METER_TYPE.POWER:
                switch (eNation)
                {
                    case NATION_NAME.ALPHA:
                        SetSliderValue(alphaPowerSlider, value);
                        break;
                    case NATION_NAME.BETA:
                        SetSliderValue(betaPowerSlider, value); ;
                        break;
                }
                break;
            case METER_TYPE.TRUST:
                switch (eNation)
                {
                    case NATION_NAME.ALPHA:
                        SetImageSprite(alphaTrustMeter, value);
                        break;
                    case NATION_NAME.BETA:
                        SetImageSprite(betaTrustMeter, value); ;
                        break;
                }
                break;
        }
    }

    void SetSliderValue(Slider sliderToSet, float value)
    {
        if (sliderToSet)
        {
            sliderToSet.value = value;
        }
    }

    void SetImageSprite(Image imageToSet, float value)
    {
        value = Mathf.Clamp(value, TRUST_MIN, TRUST_MAX);
        int index = (int)((value / TRUST_MAX) * (trustMeterSprites.Length));

        index = Mathf.Clamp(index, 0, trustMeterSprites.Length - 1);
        if (index < trustMeterSprites.Length)
        {
            imageToSet.sprite = trustMeterSprites[index];
        }
    }
}
