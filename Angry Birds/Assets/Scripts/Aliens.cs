using System.Collections;
using System.Collections.Concurrent;
using UnityEngine;
using TMPro;

public class Aliens : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Puntaje puntaje;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool siNave =collision.gameObject.GetComponent<Nave>();

        if (siNave)
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject); 
        }

        
    }

}