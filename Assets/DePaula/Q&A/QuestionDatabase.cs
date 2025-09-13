using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "QuestionDatabase", menuName = "Scriptable Objects/QuestionDatabase")]
public class QuestionDatabase : ScriptableObject
{
    public List<QuestionAnswer> database;
    int lastRand = -1, rand;

    public QuestionAnswer GetRandomItem()
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
public class QuestionAnswer
{
    [TextArea]
    public string question;
    public string correctAnswer;
    public List<string> otherOptions;

    public bool TestAnswer(string answer)
    {
        if (answer == correctAnswer)
        {
            return true;
        }

        return false;
    }

    public List<string> GetRandomizedArray()
    {
        List<string> array = otherOptions;

        array.Add(correctAnswer);

        ShuffleList(array);

        return array;
    }

    private void ShuffleList(List<string> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
}