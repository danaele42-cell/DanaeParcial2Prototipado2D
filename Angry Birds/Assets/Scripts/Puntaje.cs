using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    [SerializeField] private TextMeshProUGUI ganaste;
    private int total = 10;
    private TextMeshProUGUI textMesh;


    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        ganaste = GetComponent<TextMeshProUGUI>();
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
        textMesh.text = "Puntaje:" + puntos.ToString("0");


    }
}
