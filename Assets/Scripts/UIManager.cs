﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject MainMenu;
    public GameObject Intro;
    public GameObject ClipboardMain;
    public GameObject ClipboardScore;
    public GameObject Scoreboard;


    public Button ButtonMainStart;
    public Button ButtonMainIntro;
    public Button ButtonMainQuit;

    public Button ButtonIntroBack;

    public Button ButtonGameOverUpOne;
    public Button ButtonGameOverUpTwo;
    public Button ButtonGameOverUpThree;
    public Button ButtonGameOverDownOne;
    public Button ButtonGameOverDownTwo;
    public Button ButtonGameOverDownThree;
    public Button ButtonGameOverRestart;
    public Button ButtonGameOverExit;

    public Text TextScoreboardRequierd;
    public Text TextScoreboardCurrent;
    public Text TextScoreboardScore;

    public Text TextGameOverScore;
    public Text TextGameOverLeaderboard;
    public Text TextGameOverLetterOne;
    public Text TextGameOverLetterTwo;
    public Text TextGameOverLetterThree;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        MainMenu.SetActive(true);
        Intro.SetActive(false);
        ClipboardMain.SetActive(true);


        Button btn;

        btn = ButtonMainStart.GetComponent<Button>();
        btn.onClick.AddListener(newGame);

        btn = ButtonMainIntro.GetComponent<Button>();
        btn.onClick.AddListener(showIntro);

        btn = ButtonMainQuit.GetComponent<Button>();
        btn.onClick.AddListener(quitGame);

        btn = ButtonIntroBack.GetComponent<Button>();
        btn.onClick.AddListener(showMain);

        btn = ButtonGameOverUpOne.GetComponent<Button>();
        btn.onClick.AddListener(incrementLetterOne);

        btn = ButtonGameOverUpTwo.GetComponent<Button>();
        btn.onClick.AddListener(incrementLetterTwo);

        btn = ButtonGameOverUpThree.GetComponent<Button>();
        btn.onClick.AddListener(incrementLetterThree);

        btn = ButtonGameOverDownOne.GetComponent<Button>();
        btn.onClick.AddListener(decrementLetterOne);

        btn = ButtonGameOverDownTwo.GetComponent<Button>();
        btn.onClick.AddListener(decrementLetterTwo);

        btn = ButtonGameOverDownThree.GetComponent<Button>();
        btn.onClick.AddListener(decrementLetterThree);

        btn = ButtonGameOverExit.GetComponent<Button>();
        btn.onClick.AddListener(showMain);

        btn = ButtonGameOverRestart.GetComponent<Button>();
        btn.onClick.AddListener(newGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameOver)
        {
            TextGameOverScore.text = GameManager.Instance.Score.ToString();
            updateHighscore();
            GameOver.SetActive(true);
            ClipboardMain.SetActive(true);
        }
        else
        {
            GameOver.SetActive(false);
        }
        TextScoreboardRequierd.text = GameManager.Instance.wallPoints.ToString();
        TextScoreboardCurrent.text = GameManager.Instance.currentPoints.ToString();
        TextScoreboardScore.text = GameManager.Instance.Score.ToString();

        if(GameOver.activeSelf || MainMenu.activeSelf || Intro.activeSelf)
        {
            ClipboardScore.SetActive(false);
            Scoreboard.SetActive(false);
        }
        else
        {
            ClipboardScore.SetActive(true);
            Scoreboard.SetActive(true);
        }

        
    }

    void updateHighscore()
    {
        TextGameOverLeaderboard.text = "";
        foreach (HighScore high in GameManager.Instance.HighScores)
        {
            if (high.playerScore > 0)
                TextGameOverLeaderboard.text = TextGameOverLeaderboard.text + "\n" + high.playerName + ": " + high.playerScore;
        }
    }

    void showIntro()
    {
        MainMenu.SetActive(false);
        Intro.SetActive(true);
    }

    void showMain()
    {
        Intro.SetActive(false);
        GameManager.Instance.GameOver = false;
        GameManager.Instance.GameStarted = false;
        GameManager.Instance.SaveGame();
        GameOver.SetActive(false);
        MainMenu.SetActive(true);
    }

    void newGame()
    {
        if(GameOver.activeSelf)
            GameManager.Instance.SaveGame();
        GameOver.SetActive(false);
        Intro.SetActive(false);
        MainMenu.SetActive(false);
        ClipboardMain.SetActive(false);
        GameManager.NewGame();
    }

    void quitGame()
    {
        Application.Quit();
    }

    void incrementLetterOne()
    {
        int letterAscii = (int)TextGameOverLetterOne.text[0];
        if (letterAscii == 32)
            letterAscii = 65;
        else if (letterAscii < 90)
            letterAscii += 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextGameOverLetterOne.text = letter.ToString();
        GameManager.Instance.PlayerName = TextGameOverLetterOne.text + TextGameOverLetterTwo.text + TextGameOverLetterThree.text;
    }
    void incrementLetterTwo()
    {
        int letterAscii = (int)TextGameOverLetterTwo.text[0];
        if (letterAscii == 32)
            letterAscii = 65;
        else if (letterAscii < 90)
            letterAscii += 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextGameOverLetterTwo.text = letter.ToString();
        GameManager.Instance.PlayerName = TextGameOverLetterOne.text + TextGameOverLetterTwo.text + TextGameOverLetterThree.text;
    }
    void incrementLetterThree()
    {
        int letterAscii = (int)TextGameOverLetterThree.text[0];
        if (letterAscii == 32)
            letterAscii = 65;
        else if (letterAscii < 90)
            letterAscii += 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextGameOverLetterThree.text = letter.ToString();
        GameManager.Instance.PlayerName = TextGameOverLetterOne.text + TextGameOverLetterTwo.text + TextGameOverLetterThree.text;
    }
    void decrementLetterOne()
    {
        int letterAscii = (int)TextGameOverLetterOne.text[0];
        if (letterAscii == 32)
            letterAscii = 90;
        else if (letterAscii > 65)
            letterAscii -= 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextGameOverLetterOne.text = letter.ToString();
        GameManager.Instance.PlayerName = TextGameOverLetterOne.text + TextGameOverLetterTwo.text + TextGameOverLetterThree.text;
    }
    void decrementLetterTwo()
    {
        int letterAscii = (int)TextGameOverLetterTwo.text[0];
        if (letterAscii == 32)
            letterAscii = 90;
        else if (letterAscii > 65)
            letterAscii -= 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextGameOverLetterTwo.text = letter.ToString();
        GameManager.Instance.PlayerName = TextGameOverLetterOne.text + TextGameOverLetterTwo.text + TextGameOverLetterThree.text;
    }
    void decrementLetterThree()
    {
        int letterAscii = (int)TextGameOverLetterThree.text[0];
        if (letterAscii == 32)
            letterAscii = 90;
        else if (letterAscii > 65)
            letterAscii -= 1;
        else
            letterAscii = 32;
        char letter = (char)letterAscii;
        TextGameOverLetterThree.text = letter.ToString();
        GameManager.Instance.PlayerName = TextGameOverLetterOne.text + TextGameOverLetterTwo.text + TextGameOverLetterThree.text;
    }
}
