using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoweGreen : MonoBehaviour
{
    public GameObject linternaPrefab;   // Prefab de la linterna
    private GameObject linternaInstanciada; // Referencia a la linterna instanciada

    private bool objetoActivo = false;  // Estado de activaci�n

    public Transform player;  // Referencia al transform del jugador

    private bool linternaHabilitada = false;  // Para saber si podemos activar la linterna

    // M�todo que se ejecuta cuando el jugador colisiona con un objeto con trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto con el que colision� es el que activa la linterna
        if (other.gameObject.CompareTag("ActivadorLinterna"))
        {
            // Habilita la opci�n de la linterna
            linternaHabilitada = true;

            // Destruye el objeto con el que colisionaste
            Destroy(other.gameObject);

            Debug.Log("Linterna habilitada, presiona '1' para activarla");
        }
    }
}
