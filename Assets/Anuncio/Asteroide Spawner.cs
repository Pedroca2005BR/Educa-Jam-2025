using System.Collections.Generic;
using UnityEngine;

public class AsteroideSpawner : MonoBehaviour
{
    List<Transform> spawnPositions;
    private float lastSpawn;

    [SerializeField] List<GameObject> AsteroidePrefabs;
    
    // é feito no Awake porque vc quer pegar as posicao dentro do proprio objeto
    private void Awake()
    {
        lastSpawn = Time.time;
        spawnPositions = new List<Transform>();
        // Busca os objetos Transform dentro do proprio transform
        foreach (Transform child in transform)
        {
            spawnPositions.Add(child);
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnAsteroide", 0, 1);
        // Parar a chamada
        // CancelInvoke("SpawnAsteroide");
    }

    void SpawnAsteroide()
    {
        int spawnPos = Random.Range(0, spawnPositions.Count);
        int asteroidePrefab = Random.Range(0, AsteroidePrefabs.Count);
        
        Instantiate(AsteroidePrefabs[asteroidePrefab], 
            spawnPositions[spawnPos].position, 
            Quaternion.identity);
    }
}
