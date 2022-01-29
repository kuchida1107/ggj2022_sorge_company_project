using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    [SerializeField] StringView m_stringView;
    public int View { set => m_stringView.Set(value); }
}