using UnityEngine;
using UnityEngine.InputSystem;

public class PieceHandler : MonoBehaviour
{
    private Controles misControles;
    private GameObject piezaSeleccionada;
    private Camera mainCamera;
    private Vector2 posicionInicial, dragPosition;


    private void Awake()
    {
        misControles = new Controles();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        misControles.PajarosVcerdos.Enable();
        misControles.PajarosVcerdos.Presionado.started += Presiono;
        misControles.PajarosVcerdos.Presionado.canceled += Presiono;
     
    }

    void Presiono(InputAction.CallbackContext handler)
    {
        Vector2 pixelesACoord = Camera.main.ScreenToViewportPoint(misControles.PajarosVcerdos.Posicion.ReadValue<Vector2>());
        RaycastHit2D golpeo = Physics2D.Raycast(pixelesACoord, pixelesACoord);

        if (golpeo)
        {
            print("Pu pow");
            piezaSeleccionada = golpeo.collider.gameObject;
        }
    }

    void Solto(InputAction.CallbackContext handler) 
    {
        piezaSeleccionada = null;

    }

    private void OnMouseDrag()
    {
        if (piezaSeleccionada!= null)
        {

            transform.position = Camera.main.ScreenToViewportPoint(misControles.PajarosVcerdos.Posicion.ReadValue<Vector2>());
        }
    }


}
