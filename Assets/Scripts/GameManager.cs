using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public float tutorialTime = 5;
    public bool tutorialEnded { get; private set; } = false;
    private float timeSum = 0;

    public int points { get; private set; } = 0;
    public int currentPoints { get; private set; } = 0;
    public int Score { get; private set; } = 0;
    public bool wallIsAlive { get; private set; } = false;
    public int wallPoints { get; private set; } = 0;
    public float currentWallGapX { get; private set; } = 0;
    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject Player;
    public bool GameOver { get; set; } = false;
    public bool templateIsEnabled { get; private set; } = false;

    public string PlayerName { get; set; } = "Player 1";
    public int MaxHighScores = 4;
    public List<HighScore> HighScores = new List<HighScore>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            HighScores = IOManager.ReadSave();
            //DontDestroyOnLoad(gameObject);  // the Singelton Obj gets not deleted when change szene
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        if(timeSum >= tutorialTime)
        {
            tutorialEnded = true;
        }

        if(RightHand.transform.childCount <= 3)
        {
            OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.RTouch);
        }
        if (LeftHand.transform.childCount <= 3)
        {
            OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.LTouch);
        }
        if(Player.transform.position.z < -0.1 || Player.transform.position.z > 0.1)
        {
            Player.SetActive(false);
            Player.transform.position = new Vector3(0f, Player.transform.position.y, 0f);
            Player.SetActive(true);
        }
        if (OVRInput.Get(OVRInput.Button.Three))
        {
            NewGame();
            SceneManager.LoadScene("VR_Scene", LoadSceneMode.Single);
        }

    }

    public static void NewGame()
    {
        GameManager.Instance.points = 0;
        GameManager.Instance.Score = 0;
        GameManager.Instance.currentPoints = 0;
        GameManager.Instance.wallIsAlive = false;
        GameManager.Instance.wallPoints = 0;
        GameManager.Instance.currentWallGapX = 0;
        GameManager.Instance.GameOver = false;
        GameManager.Instance.templateIsEnabled = false;
        GameManager.Instance.HighScores = IOManager.ReadSave();

    }

    public void setPoints(bool reset)
    {
        
        if (reset)
        {
            points = 0;
        } else
        {
            points = currentPoints;
            Score += points;
        }
        
    }

    public void addCurrrentPoints(int p)
    {

        currentPoints += p;
    }

    public void setWallIsAlive(bool isAlive)
    {
        wallIsAlive = isAlive;
    }

    public void setWallPoints(int points)
    {
        wallPoints = points;
    }

    public void setCurrentWallGapX( float gap)
    {
        currentWallGapX = gap;
    }

    public void setTemplateIsEnabled(bool enabled)
    {
        templateIsEnabled = enabled;
    }

    public void setGameOver(bool _gameOver)
    {
        GameOver = _gameOver;
    }

    public void SaveGame()
    {
        HighScores.Add(new HighScore(PlayerName, Score));
        HighScores.Sort((a,b) => b.CompareTo(a));
        IOManager.WriteSave(HighScores);
    }
}
