using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Guardar la posición del checkpoint en el GameManager
            GameManager.instance.SetPlayerSpawnPosition(transform.position);
            Debug.Log("Checkpoint activado");
        }
    }
}
