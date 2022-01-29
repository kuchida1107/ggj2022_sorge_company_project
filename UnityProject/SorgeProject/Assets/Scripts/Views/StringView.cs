using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringView : MonoBehaviour
{
    [SerializeField] Text m_text;
    
    public void Set(int value)
    {
        m_text.text = value.ToString();
    }
}
