using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoints : MonoBehaviour
{

    public int wallPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setWallPoints(wallPoints);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.Instance.points >= wallPoints)
        {
            Destroy(gameObject);
            GameManager.Instance.setWallIsAlive(false);
            GameManager.Instance.setPoints(0);
        }
    }
}
