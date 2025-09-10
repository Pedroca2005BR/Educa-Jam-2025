using UnityEngine;
using System.Collections.Generic;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile; // Prefab do tile de chão
    public Transform player;      // Player
    public int numberOfTiles = 5; // Quantos tiles devem existir ao mesmo tempo
    public float tileLength = 30f;

    private float spawnZ = 0f;
    private Queue<GameObject> activeTiles = new Queue<GameObject>();

    void Start()
    {
        // Spawn inicial
        for (int i = 0; i < numberOfTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // Se o player está se aproximando do fim da fila, cria mais um tile
        if (player.position.z > spawnZ - numberOfTiles * tileLength)
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        GameObject tile = Instantiate(groundTile, new Vector3(0, 0, spawnZ), Quaternion.identity);
        activeTiles.Enqueue(tile);
        spawnZ += tileLength;

        // Remove tiles que ficaram muito para trás (quando o jogador passou 3 tiles à frente)
        // Usamos Peek() para checar o primeiro da fila sem removê-lo se a condição não for satisfeita.
        while (activeTiles.Count > 0)
        {
            GameObject first = activeTiles.Peek();
            float distance = player.position.z - first.transform.position.z;
            if (distance > tileLength * 3f)
            {
                // Jogador está a mais de 3 tiles à frente: remove o tile mais antigo
                GameObject oldTile = activeTiles.Dequeue();
                Destroy(oldTile);
            }
            else
            {
                // o tile mais antigo ainda está dentro do alcance necessário
                break;
            }
        }
    }

    // void DeleteTile()
        // {
        //     GameObject oldTile = activeTiles.Dequeue();
        //     if (player.position.z > oldTile.transform.position.z + tileLength)
        //     {
        //         Destroy(oldTile);
        //     }
        // }

}
