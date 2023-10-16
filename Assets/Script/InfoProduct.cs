using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoProduct : MonoBehaviour
{
    public TextMeshProUGUI productName, productPrize;
    private int precio;
    public Button buyButton;

    private void Start()
    {
        MoneyManager.instance.onGainMoney += DetectMoney;
        DetectMoney();
    }

    public void FillInfo(string nameProduct, int prizeProduct)
    {
        productName.text = nameProduct;
        productPrize.text = "$" +prizeProduct;
        precio = prizeProduct;
    }

    public void DetectMoney()
    {
        if (MoneyManager.instance.money >= precio)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }
}
