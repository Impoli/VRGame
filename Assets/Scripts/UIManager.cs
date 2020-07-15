using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GameOverCanvas;

    public Button ButtonRestart;
    public Button ButtonQuit;

    public Button ButtonUpOne;
    public Button ButtonUpTwo;
    public Button ButtonUpThree;
    public Button ButtonDownOne;
    public Button ButtonDownTwo;
    public Button ButtonDownThree;

    public Text Score;
    public Text ScoreBoard;
    public Text HighscoreBoard;

    public Text TextLetterOne;
    public Text TextLetterTwo;
    public Text TextLetterThree;

    // Start is called before the first frame update
    void Start()
    {
        GameOverCanvas.SetActive(false);

        Button btn;

        btn = ButtonRestart.GetComponent<Button>();
        btn.onClick.AddListener(newGame);

        btn = ButtonQuit.GetComponent<Button>();
        btn.onClick.AddListener(quitGame);

        btn = ButtonUpOne.GetComponent<Button>();
        btn.onClick.AddListener(incrementLetterOne);

        btn = ButtonUpTwo.GetComponent<Button>();
        btn.onClick.AddListener(incrementLetterTwo);

        btn = ButtonUpThree.GetComponent<Button>();
        btn.onClick.AddListener(incrementLetterThree);

        btn = ButtonDownOne.GetComponent<Button>();
        btn.onClick.AddListener(decrementLetterOne);

        btn = ButtonDownTwo.GetComponent<Button>();
        btn.onClick.AddListener(decrementLetterTwo);

        btn = ButtonDownThree.GetComponent<Button>();
        btn.onClick.AddListener(decrementLetterThree);

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

    void incrementLetterOne()
    {
        int letterAscii = (int)TextLetterOne.text[0];
        if (letterAscii == 32)
            letterAscii = 65;
        else if (letterAscii < 90)
            letterAscii += 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextLetterOne.text = letter.ToString();
        GameManager.Instance.PlayerName = TextLetterOne.text + TextLetterTwo.text + TextLetterThree.text;
    }
    void incrementLetterTwo()
    {
        int letterAscii = (int)TextLetterTwo.text[0];
        if (letterAscii == 32)
            letterAscii = 65;
        else if (letterAscii < 90)
            letterAscii += 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextLetterTwo.text = letter.ToString();
        GameManager.Instance.PlayerName = TextLetterOne.text + TextLetterTwo.text + TextLetterThree.text;
    }
    void incrementLetterThree()
    {
        int letterAscii = (int)TextLetterThree.text[0];
        if (letterAscii == 32)
            letterAscii = 65;
        else if (letterAscii < 90)
            letterAscii += 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextLetterThree.text = letter.ToString();
        GameManager.Instance.PlayerName = TextLetterOne.text + TextLetterTwo.text + TextLetterThree.text;
    }
    void decrementLetterOne()
    {
        int letterAscii = (int)TextLetterOne.text[0];
        if (letterAscii == 32)
            letterAscii = 90;
        else if (letterAscii > 65)
            letterAscii -= 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextLetterOne.text = letter.ToString();
        GameManager.Instance.PlayerName = TextLetterOne.text + TextLetterTwo.text + TextLetterThree.text;
    }
    void decrementLetterTwo()
    {
        int letterAscii = (int)TextLetterTwo.text[0];
        if (letterAscii == 32)
            letterAscii = 90;
        else if (letterAscii > 65)
            letterAscii -= 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextLetterTwo.text = letter.ToString();
        GameManager.Instance.PlayerName = TextLetterOne.text + TextLetterTwo.text + TextLetterThree.text;
    }
    void decrementLetterThree()
    {
        int letterAscii = (int)TextLetterThree.text[0];
        if (letterAscii == 32)
            letterAscii = 90;
        else if (letterAscii > 65)
            letterAscii -= 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextLetterThree.text = letter.ToString();
        GameManager.Instance.PlayerName = TextLetterOne.text + TextLetterTwo.text + TextLetterThree.text;
    }
}
