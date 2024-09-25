using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Guarda la posici�n donde el jugador aparecer� en la pr�xima escena
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

    // M�todo para definir la posici�n de aparici�n del jugador
    public void SetPlayerSpawnPosition(Vector2 position)
    {
        playerSpawnPosition = position;
    }
}
