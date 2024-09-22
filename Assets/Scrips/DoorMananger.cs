using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMananger : MonoBehaviour
{
    // Variable pública para asignar el número de la puerta
    public double doorNumber;

    // Método que se llama cuando el jugador interactúa con la puerta
    public void OpenDoor()
    {
        // Usamos un switch para decidir qué escena cargar según el número de la puerta
        switch (doorNumber)
        {
            case 1.2:
                SceneManager.LoadScene(1);
                GameManager.instance.SetPlayerSpawnPosition(new Vector2(-7, 0)); // Posición en el lado derecho
                break;
            case 2.1:
                SceneManager.LoadScene(0);
                GameManager.instance.SetPlayerSpawnPosition(new Vector2(7, 0)); // Posición en el lado derecho
                break;
            case 3:
               
                break;
            default:
                Debug.LogError("Número de puerta no asignado correctamente.");
                break;
        }
    }

    // Este ejemplo asume que OpenDoor es llamado cuando interactúas con la puerta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
}
