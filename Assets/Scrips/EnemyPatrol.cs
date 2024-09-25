using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float Speed;

    private bool isFacingRight = true;
 
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);

        bool IsPlayerRight = transform.position.x < player.transform.position.x;

        Flip(IsPlayerRight);
    }

    private void Flip(bool IsPlayerRight)
    {
        if ((isFacingRight && !IsPlayerRight) || (!isFacingRight && IsPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Verificar si el jugador es invulnerable antes de aplicar daño
            if (!GameManager.instance.IsPlayerInvulnerable())
            {
                GameManager.instance.PlayerDied();
                Debug.Log("Enemigo tocó al jugador.");
            }
            else
            {
                Debug.Log("Jugador es invulnerable, no se aplica daño.");
            }
        }
   
        
    }
}