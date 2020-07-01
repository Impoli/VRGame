using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoints : MonoBehaviour
{

    public int wallPoints = 0;
    private GameObject refCube;
    private GameObject wall;
    private GameObject podest;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setWallPoints(wallPoints);
        refCube = gameObject.transform.GetChild(1).gameObject;
        wall = this.gameObject;
        podest = GameObject.Find("Podest");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Ref Cube: " + refCube.GetComponent<Renderer>().bounds.size.x);
        GameManager.Instance.setCurrentWallGapX(refCube.GetComponent<Renderer>().bounds.size.x);

        if (wall.transform.position.z < podest.transform.position.z)
        {      
            GameManager.Instance.setWallIsAlive(false);
            GameManager.Instance.setPoints(true);
            Destroy(gameObject);
        }
    }
}
