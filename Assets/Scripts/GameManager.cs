using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public int points { get; private set; } = 0;
    public int currentPoints { get; private set; } = 0;
    public bool wallIsAlive { get; private set; } = false;
    public int wallPoints { get; private set; } = 0;
    public float currentWallGapX { get; private set; } = 0;

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
    }

    public void setPoints(int p)
    {
        points = p;
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
