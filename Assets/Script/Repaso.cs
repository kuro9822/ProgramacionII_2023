
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class Repaso : MonoBehaviour
{
    public List<string> nombres;
    public List<string> apellidos;
    public TextMeshProUGUI info;
    public string HacerNombreNuevo()
    {
        return nombres[Random.Range(0, nombres.Count)]
               + " " + apellidos[Random.Range(0, apellidos.Count)];
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            info.text = "El nuevo nombre es: " + HacerNombreNuevo();
        }
    }
}
