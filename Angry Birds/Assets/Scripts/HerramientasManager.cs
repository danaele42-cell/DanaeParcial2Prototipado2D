using UnityEngine;
using System.Collections.Generic;

public class HerramientasManager : MonoBehaviour

    
{
    public List<Herramienta> misHerramientas;
    public SpriteRenderer herramienta01;
    public SpriteRenderer herramienta02;
    public SpriteRenderer herramienta03;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        herramienta01.sprite = misHerramientas[0].sprite;
        herramienta02.sprite = misHerramientas[1].sprite;
        herramienta03.sprite = misHerramientas[2].sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
