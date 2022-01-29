using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBehaviour : MonoBehaviour
{
    [SerializeField] Text m_text;
    public int View { 
        set
        {
            m_text.text = $"${value:00000}";
        }
    }
}
