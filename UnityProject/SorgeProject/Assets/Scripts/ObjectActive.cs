using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectActive : MonoBehaviour
{
    [SerializeField] GameObject target;


    void Start()
    {
        Invoke("ResutLogo", 1f);

    }

    public void ResutLogo()
    {
        target.SetActive(true);
    }

}