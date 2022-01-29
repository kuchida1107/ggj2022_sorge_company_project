using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SorgeProject.Controller
{
    public interface IPurchase
    {
        bool IsPurchasable(Object.InfomationBehaviour infomation);
        void Purchase(Object.InfomationBehaviour infomation);
    }

    public class PlayerDataConroller : MonoBehaviour, IController, IPurchase
    {
        [SerializeField] int initMoney = 100;

        [SerializeField] Object.HandBehaviour hand;

        [SerializeField] MoneyBehaviour m_money;


        public bool IsInitialized => true;

        public void PlayStart()
        {
            PlayingTime = 0f;
            Money = initMoney;

            hand.Controller = this;
        }

        public void PlayUpdate()
        {
            PlayingTime += Time.deltaTime;
            m_money.View = Money;
        }

        public void Setup(){}

        public float PlayingTime { get; private set; }

        public int Money { get; private set; }

        public bool IsPurchasable(Object.InfomationBehaviour infomation)
        {
            return infomation.Cost < Money;
        }

        public void Purchase(Object.InfomationBehaviour infomation)
        {
            Debug.Log(infomation.Cost);
            Debug.Log(Money);
            Money -= infomation.Cost;
        }
    }
}