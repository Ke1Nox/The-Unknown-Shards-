using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzActive : MonoBehaviour
{
    public GameObject linternaPrefab;   // Prefab de la linterna
    private GameObject linternaInstanciada; // Referencia a la linterna instanciada

    private bool linternaHabilitada = false;  // Para verificar si podemos activar la linterna

    public Transform player;  // Referencia al transform del jugador

    // Referencia a la Sprite Mask
    public SpriteMask spriteMask;

    // Valores originales de la escala de la máscara
    private Vector2 originalMaskScale;

    // Escala que tendrá la máscara cuando la linterna esté activa
    public Vector2 linternaMaskScale = new Vector2(2f, 2f);  // x2 de visión

    void Start()
    {
        // Guarda la escala original de la máscara
        if (spriteMask != null)
        {
            originalMaskScale = spriteMask.transform.localScale;
        }
    }

    void Update()
    {
        // Verifica si la linterna ha sido habilitada y presionas la tecla "1"
        if (linternaHabilitada && Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Si la linterna aún no ha sido instanciada, la instancia en la posición del jugador
            if (linternaInstanciada == null)
            {
                linternaInstanciada = Instantiate(linternaPrefab, player.position, Quaternion.identity);
                linternaInstanciada.SetActive(true);  // Activar la linterna al instanciarla

                // Aumentar la visión (cambiar la escala de la máscara)
                if (spriteMask != null)
                {
                    spriteMask.transform.localScale = linternaMaskScale;
                }
            }
            else
            {
                // Alterna el estado de activación de la linterna
                bool isActive = linternaInstanciada.activeSelf;
                linternaInstanciada.SetActive(!isActive);  // Alternar activación

                // Si la linterna está activa, aumentar la visión, si no, restaurar la visión original
                if (spriteMask != null)
                {
                    spriteMask.transform.localScale = isActive ? originalMaskScale : linternaMaskScale;
                }
            }
        }

        // Si la linterna está instanciada, que siga al jugador
        if (linternaInstanciada != null)
        {
            linternaInstanciada.transform.position = player.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)  //colision con el objeto para activar el script del power
    {
        // Verifica si el objeto con el que colisionó es el que activa la linterna
        if (other.gameObject.CompareTag("ActivadorLinterna"))
        {
            // Habilita la opción de la linterna
            linternaHabilitada = true;
            GetComponent<LuzActive>().enabled = true;
            // Destruye el objeto con el que colisionaste
            Destroy(other.gameObject);

            Debug.Log("Script de linterna activado");
        }
    }
}




