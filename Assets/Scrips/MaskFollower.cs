using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskFollower : MonoBehaviour
{
    public Transform player; // Asigna aqu� el transform del jugador

    void Update()
    {
        // Actualiza la posici�n del SpriteMask para que siga al jugador
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
