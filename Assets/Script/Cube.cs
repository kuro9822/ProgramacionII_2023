using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cube : MonoBehaviour
{
    public bool isSuscribed;
    public void Shake()
    {
        transform.DOShakePosition(1);
    }
    private void OnMouseDown()
    {
        if (isSuscribed)
        {
            CubeManager.instance.onPressButton -= Shake;
            isSuscribed = false;
        }
        else if(!isSuscribed)
        {
            CubeManager.instance.onPressButton += Shake;
            isSuscribed = true;
        }
    }
}
