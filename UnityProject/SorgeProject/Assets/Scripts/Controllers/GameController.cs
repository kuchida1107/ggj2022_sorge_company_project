using System.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

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

        public Status Current { get; private set; }
    }

    public enum Status
    {
        Setup,
        Playing
    }
}