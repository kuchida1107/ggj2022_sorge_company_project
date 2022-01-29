using SorgeProject.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        string liveDay = GameController.LastScore != null ? GameController.LastScore.day.ToString() : "99";
        text.text = $"諜報活動日数　{liveDay}日";
    }
}
