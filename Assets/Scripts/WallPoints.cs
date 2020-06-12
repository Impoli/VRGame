using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoints : MonoBehaviour
{

    public int wallPoints = 0;
    public GameObject refCube;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setWallPoints(wallPoints);
        refCube = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Ref Cube: " + refCube.GetComponent<Renderer>().bounds.size.x);
        GameManager.Instance.setCurrentWallGapX(refCube.GetComponent<Renderer>().bounds.size.x);

        if (GameManager.Instance.points >= wallPoints)
        {
            Destroy(gameObject);
            GameManager.Instance.setWallIsAlive(false);
            GameManager.Instance.setPoints(true);
        }
    }
}
