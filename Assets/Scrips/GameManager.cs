using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Guarda la posición donde el jugador aparecerá en la próxima escena
    public Vector2 playerSpawnPosition;

    // Para asegurarte de que el GameManager persiste entre escenas
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para definir la posición de aparición del jugador
    public void SetPlayerSpawnPosition(Vector2 position)
    {
        playerSpawnPosition = position;
    }
}
