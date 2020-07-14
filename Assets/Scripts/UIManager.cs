using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverCanvas;
    public Button RestartButton;
    public Button QuitButton;
    public Text Score;
    public Text ScoreBoard;
    public Text HighscoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);

        Button btn;

        btn = RestartButton.GetComponent<Button>();
        btn.onClick.AddListener(newGame);

        btn = QuitButton.GetComponent<Button>();
        btn.onClick.AddListener(quitGame);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameOver )
        {
            Score.text = "Your Score is: " + GameManager.Instance.Score;
            GameOverCanvas.SetActive(true);
        }
        ScoreBoard.text = "Wall Points: " + GameManager.Instance.wallPoints
            + "\nStack Points: " + GameManager.Instance.currentPoints
            + "\nScore: " + GameManager.Instance.Score;
        
        foreach(HighScore high in GameManager.Instance.HighScores)
        {
            HighscoreBoard.text = HighscoreBoard.text + "\n" + high.playerName + ": " + high.playerScore;
        }
    }

    void newGame()
    {
        GameManager.Instance.SaveGame();
        GameManager.NewGame();
        SceneManager.LoadScene("VR_Scene", LoadSceneMode.Single);
    }

    void quitGame()
    {
        GameManager.Instance.SaveGame();
        Application.Quit();
    }

}
