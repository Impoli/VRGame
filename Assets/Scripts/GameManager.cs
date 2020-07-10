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
    public bool wallIsAlive { get; private set; } = false;
    public int wallPoints { get; private set; } = 0;
    public float currentWallGapX { get; private set; } = 0;
    public GameObject RightHand;
    public GameObject LeftHand;
    public GameObject Player;
    public bool GameOver { get; set; } = false;
    public bool templateIsEnabled { get; private set; } = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
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
        GameObject pt = GameObject.Find("PointsText");
        pt.GetComponent<UnityEngine.UI.Text>().text = string.Format("Wall Points: {0} \nCurrent Points: {1} \n {2} ",wallPoints, currentPoints, points );

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
        GameManager.Instance.currentPoints = 0;
        GameManager.Instance.wallIsAlive = false;
        GameManager.Instance.wallPoints = 0;
        GameManager.Instance.currentWallGapX = 0;
        GameManager.Instance.GameOver = false;
        GameManager.Instance.templateIsEnabled = false;

    }

    public void setPoints(bool reset)
    {
        
        if (reset)
        {
            points = 0;
        } else
        {
            points = currentPoints;
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

}
