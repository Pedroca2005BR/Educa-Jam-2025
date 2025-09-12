using System.Collections;
using TMPro;
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

    [Header("Referencias")]
    [SerializeField] TextMeshProUGUI scoreTextComponent;
    [SerializeField] TextMeshProUGUI livesTextComponent;
    [SerializeField] LoseScreenController loseScreen;

    public int maxLives = 3;
    public int score { get; private set; } = 0;
    public int lives { get; private set; }
    

    private string scoreString;

    private void SaveScore()
    {
        PlayerPrefs.SetInt($"{scoreString}Score", score);
    }

    public void ScoreUp(int amount = 1)
    {
        score += amount;
        scoreTextComponent.text = score.ToString();
    }

    public void LoseLife()
    {
        lives--;
        livesTextComponent.text = lives.ToString();


        if (lives <= 0)
        {
            SaveScore();
            IEnumerator coroutine = LoseCoroutine();
            StartCoroutine(coroutine);
        }
    }

    public void SetVariables(string minigame, int difficultyLevel, string subject)
    {
        Time.timeScale = 1f;
        lives = maxLives;
        score = 0;
        scoreString = minigame + difficultyLevel.ToString();
        loseScreen.gameObject.SetActive(false);

        livesTextComponent.text = lives.ToString();
        scoreTextComponent.text = score.ToString();
    }

    IEnumerator LoseCoroutine()
    {
        yield return new WaitForSeconds(1f);
        loseScreen.gameObject.SetActive(true);
        loseScreen.Setup(scoreString);
        Time.timeScale = 0f;
    }
}
