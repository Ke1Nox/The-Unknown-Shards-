using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Vector2 playerSpawnPosition;
    private bool isPlayerDead = false;

    // Referencia directa al jugador
    private GameObject player;

    private SpriteRenderer playerRenderer; // Referencia al SpriteRenderer del jugador para efecto visual
    private bool isInvulnerable = false; // Controla si el jugador es invulnerable
    public float invulnerableDuration = 2.0f; // Duración de la invulnerabilidad

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

    //private void Start()
    //{
    //    // Encontrar al jugador al inicio del juego
    //    player = GameObject.FindWithTag("Player");
    //    if (player != null)
    //    {
    //        playerRenderer = player.GetComponent<SpriteRenderer>();  // Obtener el SpriteRenderer para efectos visuales
    //    }
    //    else
    //    {
    //        Debug.LogError("No se encontró el objeto Player en la escena.");
    //    }
    //}

    public void SetPlayerSpawnPosition(Vector2 position)
    {
        playerSpawnPosition = position;
    }

    public void PlayerDied()
    {
        if (!isPlayerDead && player != null) // Solo se ejecuta si el jugador no ha muerto ya y el jugador existe
        {
            isPlayerDead = true; // Marcamos que el jugador está muerto
            Debug.Log("Jugador ha muerto.");

            player.SetActive(false); // Desactiva al jugador
            Invoke("RespawnPlayer", 2.5f); // Retraso de 2.5 segundos para reaparecer
        }
    }

    //void RespawnPlayer()
    //{
    //    if (player != null)
    //    {
    //        // Reubicar al jugador en la posición guardada en el checkpoint
    //        player.transform.position = playerSpawnPosition;

    //        player.SetActive(true); // Reactivar al jugador

    //        StartCoroutine(Invulnerability()); // Iniciar la invulnerabilidad temporal

    //        isPlayerDead = false; // Restablecer el estado de muerte

    //        Debug.Log("Jugador ha respawneado");
    //    }
    //    else
    //    {
    //        Debug.LogError("No se encontró el jugador para respawnear.");
    //    }
    //}

    //public void RestartScene()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia la escena actual
    //}

    // Corrutina de invulnerabilidad
    //IEnumerator Invulnerability()
    //{
    //    isInvulnerable = true;
    //    Debug.Log("Jugador es invulnerable.");

    //    float timer = 0;

    //    while (timer < invulnerableDuration)
    //    {
    //        playerRenderer.enabled = !playerRenderer.enabled; // Alternar visibilidad
    //        timer += 0.2f; // Cambia este valor para ajustar la velocidad del parpadeo
    //        yield return new WaitForSeconds(0.2f);
    //    }

    //    // Asegurarse de que el jugador esté visible al final
    //    playerRenderer.enabled = true;
      

    //    isInvulnerable = false;
    //    Debug.Log("Invulnerabilidad terminada.");
    //}

    // Método para chequear si el jugador es invulnerable
    public bool IsPlayerInvulnerable()
    {
        return isInvulnerable;
    }
}



