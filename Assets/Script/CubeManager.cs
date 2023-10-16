using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeManager : MonoBehaviour
{
    public static CubeManager instance;
    public Action onPressButton;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            onPressButton?.Invoke();
        }
    }
}
