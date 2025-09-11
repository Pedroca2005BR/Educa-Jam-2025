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
        GameObject tileObj = Instantiate(groundTile, new Vector3(0, 0, spawnZ), Quaternion.identity);
        activeTiles.Enqueue(tileObj);
        spawnZ += tileLength;
        
        // --- SPAWN DOS PORTÕES ---
        GroundTile tile = tileObj.GetComponent<GroundTile>();
        if (tile != null && tile.gateSpawnPoint != null)
        {
            GateSpawner gateSpawner = FindFirstObjectByType<GateSpawner>();
            if (gateSpawner != null)
            {
                gateSpawner.SpawnGateAt(tile.gateSpawnPoint.position, tileObj.transform); // <- aqui o tile é o pai
            }
        }



        // --- LIMPEZA DOS TILES ANTIGOS ---
        while (activeTiles.Count > 0)
        {
            GameObject first = activeTiles.Peek();
            float distance = player.position.z - first.transform.position.z;
            if (distance > tileLength * 3f)
            {
                GameObject oldTile = activeTiles.Dequeue();
                Destroy(oldTile);
            }
            else break;
        }
    }
}
