using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public MathQuestion[] questions;

    public MathQuestion GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Length);
        return questions[index];
    }

    public int GetWrongAnswer(int correct)
    {
        int offset = Random.Range(1, 5);
        return Random.value > 0.5f ? correct + offset : correct - offset;
    }
}
