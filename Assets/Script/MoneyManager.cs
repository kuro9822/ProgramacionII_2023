using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money;
    private float timer = 1;
    private float actualtimer = 0;
    public TextMeshProUGUI moneyUI;
    public Action onGainMoney;
    private void Awake()
    {
        instance = this;
    }
   
    void Update()
    {
        if (actualtimer < timer)
        {
            actualtimer += 1 * Time.deltaTime;
            if (actualtimer >= timer)
            {
                actualtimer = 0;
                AddMoney(1);
            }
        }
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyUI.text = "$" + money;
        onGainMoney?.Invoke();
    }
}
