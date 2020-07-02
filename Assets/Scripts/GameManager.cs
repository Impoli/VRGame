using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public float tutorialTime = 3;
    public bool tutorialEnded { get; private set; } = false;
    private float timeSum = 0;

    public int points { get; private set; } = 0;
    public int currentPoints { get; private set; } = 0;
    public bool wallIsAlive { get; private set; } = false;
    public int wallPoints { get; private set; } = 0;
    public float currentWallGapX { get; private set; } = 0;
    public GameObject RightHand;
    public GameObject LeftHand;

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

}
