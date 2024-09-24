using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWarManager : MonoBehaviour
{
    public GameObject fogOfWarPlane; // El plano o sprite que cubre el mapa con "fog"
    public Transform player; // El jugador o el objeto cuyo avance despeja el fog
    public float revealRadius = 5f; // Radio de revelación alrededor del jugador

    private Mesh fogMesh;
    private Vector3[] vertices;
    private Color[] colors;

    void Start()
    {
        fogMesh = fogOfWarPlane.GetComponent<MeshFilter>().mesh;
        vertices = fogMesh.vertices;
        colors = new Color[vertices.Length];

        // Inicializar todo con el fog oscuro
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.black;
        }

        UpdateFog();
    }

    void Update()
    {
        UpdateFog();
    }

    void UpdateFog()
    {
        Vector3 playerPos = player.position;

        // Recorre los vértices del fog y elimina el fog alrededor del jugador
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertexWorldPos = fogOfWarPlane.transform.TransformPoint(vertices[i]);
            float dist = Vector3.Distance(vertexWorldPos, playerPos);

            // Si está dentro del radio de revelación, elimina el fog
            if (dist < revealRadius)
            {
                float alpha = Mathf.Min(colors[i].a, dist / revealRadius);
                colors[i].a = alpha;
            }
        }

        fogMesh.colors = colors;
    }
}

