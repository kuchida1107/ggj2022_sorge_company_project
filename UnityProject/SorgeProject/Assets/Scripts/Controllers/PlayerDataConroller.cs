using SorgeProject.Object;
using SorgeProject.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SorgeProject.Controller
{
    public class PlayerDataConroller : MonoBehaviour, IController
    {
        [SerializeField] int initMoney = 100;

        [SerializeField] Object.HandBehaviour hand;

        [SerializeField] MoneyBehaviour m_money;

        public bool IsInitialized => true;

        public void PlayStart()
        {
            PlayingTime = 0f;
            Money = initMoney;
        }

        public void PlayUpdate()
        {
            PlayingTime += Time.deltaTime;
            m_money.View = Money;
        }

        public void Setup() {
            Instance = this;
        }

        public float PlayingTime { get; private set; }

        public int Money { get; private set; }

        public bool IsPurchasable(Object.InfomationBehaviour infomation)
        {
            return infomation.Cost < Money;
        }

        public void Purchase(InfomationBehaviour infomation)
        {
            Money -= infomation.Cost;
            hand.PushInfomation(infomation);
        }

        public void Move(InfomationBehaviour infomation, RegionBehaviour src, RegionBehaviour dst)
        {
            Money -= infomation.Cost;
            Money += infomation.SellCost;
            dst.ReceiveInfomation(infomation);
        }

        public void Sell(InfomationBehaviour infomation, RegionBehaviour target)
        {
            Money += infomation.SellCost;
            hand.RemoveInfomation(infomation);
            target.ReceiveInfomation(infomation);
        }

        public static PlayerDataConroller Instance { get; private set; }
    }
}