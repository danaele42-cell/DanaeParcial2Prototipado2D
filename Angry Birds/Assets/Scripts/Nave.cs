using UnityEngine;
using TMPro;
public class Nave : MonoBehaviour
{
    [SerializeField] private float fuerza;

    private int tiros = 3;
    private bool tirosRestantes;

    [SerializeField] private float distMaxima;
    private Camera mainCamera;
    private Rigidbody2D rb;
    private Vector2 posicionInicial, posicionLimite;
    public TextMeshProUGUI intentos;
    public TextMeshProUGUI ganaste;
    public TextMeshProUGUI perdiste;


    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        posicionInicial = transform.position;
    }

    //Agarramos la nava, delimitamos su radio de movimiento, evitamos que se pueda lanzar de drecha a izquierda
    private void OnMouseDrag()
    {
        Vector2 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        posicionLimite = dragPosition;
        

        float dragDistance = Vector2.Distance(posicionInicial, dragPosition);

        if (dragDistance > distMaxima) {
            posicionLimite = posicionInicial + (dragPosition - posicionInicial).normalized * distMaxima;
                }

        if (dragPosition.x > posicionInicial.x)
        {
            posicionLimite.x = posicionInicial.x;
        }

        transform.position = posicionLimite;

    }
    //Aventamos la nave
    private void OnMouseUp()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Vector2 throwVector = posicionInicial - posicionLimite;
        rb.AddForce(throwVector * fuerza);

        float reseto = 5f;
        Invoke("Resetar", reseto);
    }

    private void Resetar()
    {
        transform.position = posicionInicial;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;

        tiros = tiros - 1;
        if (tiros == 3)
        {
            intentos.text = ":" + tiros;
            tirosRestantes = true;
        }
        else if (tiros == 2) 
        {
            intentos.text = ":" + tiros;
            tirosRestantes = true;
        }
        else if (tiros == 1) 
        {
            intentos.text = ":" + tiros;
            tirosRestantes = true;
        }
        else if (tiros == 0) 
        {
            intentos.text = ":" + tiros;
            tirosRestantes = false;
            perdiste.text = "HAS PERDIDO";
        }
    }


}
