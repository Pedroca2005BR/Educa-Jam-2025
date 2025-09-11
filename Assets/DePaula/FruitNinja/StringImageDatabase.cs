using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StringDatabase", menuName = "Scriptable Objects/StringDatabase")]
public class StringImageDatabase : ScriptableObject
{
    public List<StringImageTuple> database;
    int lastRand = -1, rand;

    public StringImageTuple GetRandomItem()
    {
        if (database == null)
        {
            Debug.LogError("Database is null");
            return null;
        }

        do
        {
            rand = Random.Range(0, database.Count);
        } while (lastRand == rand);

        lastRand = rand;

        return database[rand];
    }
}

[System.Serializable]
public class StringImageTuple
{
    public string text;
    public Sprite image;
    public bool isCorrectAnswer;

    public StringImageTuple(string text, Sprite image)
    {
        this.text = text;
        this.image = image;
    }
}