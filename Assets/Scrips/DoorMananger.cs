using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorMananger : MonoBehaviour
{
    // Variable p�blica para asignar el n�mero de la puerta
    public double doorNumber;

    // M�todo que se llama cuando el jugador interact�a con la puerta
    public void OpenDoor()
    {
        // Usamos un switch para decidir qu� escena cargar seg�n el n�mero de la puerta
        switch (doorNumber)
        {
            case 1.2:
                SceneManager.LoadScene(1);
                GameManager.instance.SetPlayerSpawnPosition(new Vector2(-7, 0)); // Posici�n en el lado derecho
                break;
            case 2.1:
                SceneManager.LoadScene(0);
                GameManager.instance.SetPlayerSpawnPosition(new Vector2(7, 0)); // Posici�n en el lado derecho
                break;
            case 3:
               
                break;
            default:
                Debug.LogError("N�mero de puerta no asignado correctamente.");
                break;
        }
    }

    // Este ejemplo asume que OpenDoor es llamado cuando interact�as con la puerta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
}
