using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace SorgeProject.Controller
{
    public interface IController
    {
        void Setup();
        void PlayUpdate();
        void PlayStart();
        bool IsInitialized { get; }
    }

    public class GameController : MonoBehaviour
    {
        IController[] controllers;
        void Start()
        {
            Instance = this;
            LastScore = null;

            Current = Status.Setup;

            controllers = gameObject.GetComponents<IController>();

            ControllersForeach((controller) => controller.Setup());
        }

        void Update()
        {
            switch (Current)
            {
                case Status.Setup:
                    UpdateOnSetup();
                    break;

                case Status.Playing:
                    UpdateOnPlay();
                    break;
            }
        }

        void UpdateOnSetup()
        {
            if (!IsInitialized()) return;
            Current = Status.Playing;
            ControllersForeach(controller => controller.PlayStart());
        }

        void UpdateOnPlay()
        {
            ControllersForeach(controller => controller.PlayUpdate());
        }

        bool IsInitialized()
        {
            return controllers.FirstOrDefault(c => !c.IsInitialized) == null;
        }

        void ControllersForeach(System.Action<IController> action)
        {
            foreach (var controller in controllers) action(controller);
        }

        public void GameEnd(EndingType endingType)
        {
            var controller = GetComponent<PlayerDataConroller>();
            LastScore = new EndingParams();
            LastScore.day = (int)controller.PlayingTime;
            LastScore.money = (int)controller.Money;

            switch(endingType)
            {
                case EndingType.ALPHA_WIN:
                    SceneManager.LoadScene("Ending-winA");
                    break;
                case EndingType.BETA_WIN:
                    SceneManager.LoadScene("Ending-winB");
                    break;
                case EndingType.COLD_WAR:
                    SceneManager.LoadScene("Ending-cold");
                    break;
                case EndingType.PEACE:
                    SceneManager.LoadScene("Ending-peace");
                    break;
                case EndingType.BURN_WAR:
                    SceneManager.LoadScene("Ending-burn");
                    break;
                case EndingType.DEATH:
                    SceneManager.LoadScene("Ending-kill");
                    break;
            }
        }

        public Status Current { get; private set; }

        static public GameController Instance { get; private set; }
        static public EndingParams LastScore { get; private set; }
    }

    public enum Status
    {
        Setup,
        Playing
    }

    public enum EndingType
    {
        ALPHA_WIN,
        BETA_WIN,
        COLD_WAR,
        BURN_WAR,
        PEACE,
        DEATH
    }

    public class EndingParams
    {
        public int day;
        public int money;
    }
}