using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button playAgainButton;
    public Button exitButton;
    void Start()
    {
        // Hiển thị điểm số cuối cùng
        scoreText.text = "Final Score: " + PlayerPrefs.GetInt("PlayerScore", 0);

        // Xử lý nút Play Again
        playAgainButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        exitButton.onClick.AddListener(QuitGame);
    }
    void QuitGame()
    {
        Debug.Log("Exiting game...");
        UnityEditor.EditorApplication.isPlaying = false; 
        Application.Quit();
    }
}
