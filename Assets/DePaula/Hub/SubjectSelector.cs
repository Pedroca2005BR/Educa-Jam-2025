using UnityEngine;
using UnityEngine.SceneManagement;

public class SubjectSelector : MonoBehaviour
{
    public Subject subject;
    public string sceneName;

    public void GoToMinigame()
    {
        PlayerPrefs.SetInt("Subject", (int)subject);
        SceneManager.LoadScene(sceneName);
    }
}
