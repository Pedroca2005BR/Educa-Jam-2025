using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class QuestionsGenerator : MonoBehaviour
{
    [Header("TextComponents")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<TextMeshProUGUI> answersText;
    [Space]
    [Header("Databases")]
    public List<QuestionDatabaseConfig> databases;

    int difficultyLevel = 0;
    Subject currentSubject = Subject.Portuguese;

    QuestionAnswer currentQuestion;

    private void Start()
    {
        currentSubject = (Subject)PlayerPrefs.GetInt("Subject", 1);
    }

    private QuestionAnswer GetRandomItem()
    {
        foreach (var item in databases)
        {
            if (item.subject == currentSubject && item.level == difficultyLevel)
            {
                return item.database.GetRandomItem();
            }
        }

        Debug.LogError("Can't find suitable database to get item from!");
        return null;
    }

    public void GenerateQuestionAnswer(int level = 0)
    {
        if (level != 0)
        {
            difficultyLevel = level;
        }

        currentQuestion = GetRandomItem();

        if (currentQuestion == null) return;

        questionText.text = currentQuestion.question;

        List<string> array = currentQuestion.GetRandomizedArray();

        for(int i = 0; i < array.Count; i++)
        {
            answersText[i].text = array[i];
        }
    }

    public void ChooseAnswer(TextMeshProUGUI answer)
    {
        if (currentQuestion == null) return;

        if (currentQuestion.TestAnswer(answer.text))
        {
            ScoreManager.instance.ScoreUp();
        }
        else
        {
            ScoreManager.instance.LoseLife();
        }
    }
}


[System.Serializable]
public class QuestionDatabaseConfig
{
    public QuestionDatabase database;
    public Subject subject;
    public int level;
}