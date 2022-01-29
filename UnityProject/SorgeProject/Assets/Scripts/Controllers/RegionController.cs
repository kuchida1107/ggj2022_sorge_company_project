using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SorgeProject.Controller
{
    public class RegionController : MonoBehaviour, IController
    {
        [SerializeField] NationMeterController meterController;
        [SerializeField] RegionParams initParams;

        RegionParams alphaniaParam;
        RegionParams betalandParam;

        public bool IsInitialized => true;

        public void PlayStart()
        {
            alphaniaParam = new RegionParams(initParams);
            betalandParam = new RegionParams(initParams);
        }

        public void PlayUpdate()
        {
            ViewUpdate();
        }

        private void ViewUpdate()
        {
            meterController.SetMeterValue(NationMeterController.METER_TYPE.POWER, NATION_NAME.ALPHA, alphaniaParam.power);
            meterController.SetMeterValue(NationMeterController.METER_TYPE.MORAL, NATION_NAME.ALPHA, alphaniaParam.moral);
            meterController.SetMeterValue(NationMeterController.METER_TYPE.TRUST, NATION_NAME.ALPHA, alphaniaParam.trust);
            meterController.SetMeterValue(NationMeterController.METER_TYPE.POWER, NATION_NAME.BETA, betalandParam.power);
            meterController.SetMeterValue(NationMeterController.METER_TYPE.MORAL, NATION_NAME.BETA, betalandParam.moral);
            meterController.SetMeterValue(NationMeterController.METER_TYPE.TRUST, NATION_NAME.BETA, betalandParam.trust);
        }

        public void Setup() 
        {
            Instance = this;
        }

        public static RegionController Instance { get; private set; }

        internal void AddParameter(NATION_NAME m_name, int power, int moral, int trust)
        {
            RegionParams target;
            switch(m_name)
            {
                case NATION_NAME.ALPHA:
                    target = alphaniaParam;
                    break;
                case NATION_NAME.BETA:
                    target = betalandParam;
                    return;
                default: throw new Exception($"not defined NATION_NAME {m_name}");
            }

            target.power += power;
            target.moral += moral;
            target.trust += trust;
        }
    }

    [System.Serializable]
    public class RegionParams
    {
        public int power = 50;
        public int moral = 50;
        public int trust = 50;
        public RegionParams(RegionParams src)
        {
            power = src.power;
            moral = src.moral;
            trust = src.trust;
        }
    }
}