using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    #endregion

    public int maxLives = 3;
    public int score = 0;
    public int lives { get; private set; }
    [SerializeField] GameObject loseScreen;

    private string scoreString;

    public void SaveScore()
    {
        PlayerPrefs.SetInt($"{scoreString}Score", score);

        if (score > PlayerPrefs.GetInt($"{scoreString}Highscore", 0))
        {
            PlayerPrefs.SetInt($"{scoreString}Highscore", score);
        }
    }

    public void LoseLife()
    {
        lives--;

        if (lives <= 0)
        {
            SaveScore();
            IEnumerator coroutine = LoseCoroutine();
            StartCoroutine(coroutine);
        }
    }

    public void SetVariables(string minigame, int difficultyLevel, string subject)
    {
        lives = maxLives;
        score = 0;
        scoreString = minigame + difficultyLevel.ToString();
        loseScreen.SetActive(false);
    }

    IEnumerator LoseCoroutine()
    {
        yield return new WaitForSeconds(1f);
        loseScreen.SetActive(true);
    }
}
