using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int score = 0;
    public Text scoreText;

    private void Awake()
    {
        scoreText.text = "Score: " + score.ToString();
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("PlayerScore", score);
    }

}
