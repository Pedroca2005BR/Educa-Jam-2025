using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LoseScreenController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    [SerializeField] TextMeshProUGUI highscore;

    public void Setup(string scoreString)
    {
        int score = PlayerPrefs.GetInt($"{scoreString}Score");
        int highscore = PlayerPrefs.GetInt($"{scoreString}Highscore", 0);
        finalScore.text = "Pontuação: " + score.ToString();

        if (this.highscore == null) return;

        if (score > highscore)
        {
            PlayerPrefs.SetInt($"{scoreString}Highscore", score);

            this.highscore.text = "Novo Recorde!!!!";
        }
        else
        {
            this.highscore.text = "Seu Recorde: " + highscore.ToString();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
