using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Collections;

public class WordSpawner : MonoBehaviour
{
    [Header("Spawn Data")]
    [SerializeField] GameObject baseObject;
    [SerializeField] Transform spawnAreaStart;
    [SerializeField] Transform spawnAreaEnd;
    public SquareArea throwForceLimits;
    [Space]
    [Range(0.1f, 5f)] public float spawnCooldown = 1f;

    [Space]
    [SerializeField] List<DatabaseConfig> databases = new List<DatabaseConfig>();

    int difficultyLevel = 0;
    Subject currentSubject = Subject.Portuguese;

    private void Start()
    {
        currentSubject = (Subject)PlayerPrefs.GetInt("Subject", 1);
    }





    public void StartSpawning()
    {
        IEnumerator coroutine = SpawnCoroutine();
        StartCoroutine(coroutine);
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        { 
            SpawnItem();
            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    private void SpawnItem()
    {
        StringImageTuple tuple = GetRandomItem();

        if (tuple == null) return;


        // Randomizar posicao
        Vector2 pos = new Vector2(Random.Range(spawnAreaStart.position.x, spawnAreaEnd.position.x), Random.Range(spawnAreaStart.position.y, spawnAreaEnd.position.y));

        GameObject obj = Instantiate(baseObject, pos, Quaternion.identity, transform);

        // Adicionar texto e imagem
        if (tuple.text == null)
        {
            // Se não ha nenhum dos dois, tem algo de errado
            if (tuple.image == null)
            {
                Debug.LogWarning("Empty Item found! Canceling spawn...");
                Destroy(obj);
                return;
            }

            // Se há imagem, coloca a imagem
            obj.GetComponent<CuttableBehaviour>().SetImage(tuple.image);
        }
        else
        {
            // Se há texto, coloca o texto
            obj.GetComponent<CuttableBehaviour>().SetText(tuple.text);

            if (tuple.image != null)
            {
                // Se há imagem, coloca a imagem
                obj.GetComponent<CuttableBehaviour>().SetImage(tuple.image);
            }
        }

        // Randomizar forca
        float x = Random.Range(throwForceLimits.X1, throwForceLimits.X2);
        float y = Random.Range(throwForceLimits.Y1, throwForceLimits.Y2);

        // Se o valor de x for maior que 0 (parte direita da tela), transforma o movimento lateral em negativo para jogar pro outro lado
        if (pos.x > 0)
        {
            x *= -1;
        }

        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(x, y));

        // Settar se eh resposta certa
        obj.GetComponent<CuttableBehaviour>().correctAnswer = tuple.isCorrectAnswer;
    }



    private StringImageTuple GetRandomItem()
    {
        foreach(var item in databases)
        {
            if (item.subject == currentSubject && item.level == difficultyLevel)
            {
                return item.database.GetRandomItem();
            }
        }

        Debug.LogError("Can't find suitable database to get item from!");
        return null;
    }
}

[System.Serializable]
public class DatabaseConfig
{
    public StringImageDatabase database;
    public Subject subject;
    public int level;
}

[System.Serializable]
public struct SquareArea
{
    public float X1;
    public float Y1;
    public float X2;
    public float Y2;
}