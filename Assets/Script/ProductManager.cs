using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public static ProductManager instance;
    public Dictionary<string, int> products = new Dictionary<string, int>();
    public GameObject productInfo;
    public Transform scroll;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        products.Add("Manzana",20);
        products.Add("Pera",15);
        products.Add("Sandia",30);

        products["Manzana"] += 20;

        foreach (var p in products)
        {
            GameObject go = Instantiate(productInfo, scroll);
            go.GetComponent<InfoProduct>().
                FillInfo(p.Key,p.Value);
        }
        
    }
}
