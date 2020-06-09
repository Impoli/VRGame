using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public int points { get; private set; } = 0;
    public int currentPoints { get; private set; } = 0;

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
        pt.GetComponent<UnityEngine.UI.Text>().text = "Points: " + currentPoints;
    }

    public void addPoints(int p)
    {
        points += p;
    }

    public void addCurrrentPoints(int p)
    {
        currentPoints += p;
    }
}
