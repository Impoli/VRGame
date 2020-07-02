using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoints : MonoBehaviour
{

    public int wallPoints = 0;
    private GameObject refCube;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setWallPoints(wallPoints);
       
        for (int i = 0; i < gameObject.transform.childCount ; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.tag == "wallRefCube")
            {
                refCube = gameObject.transform.GetChild(i).gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Ref Cube: " + refCube.GetComponent<Renderer>().bounds.size.x);
        GameManager.Instance.setCurrentWallGapX(refCube.GetComponent<Renderer>().bounds.size.x);

        if (GameManager.Instance.points >= wallPoints)
        {
            //GameManager.Instance.setWallIsAlive(false);
            //GameManager.Instance.setPoints(true);
            // Destroy(gameObject);
        }

        if (GameObject.Find("Podest_schiene").transform.position.z - transform.position.z > 0.35)
        {
            GameManager.Instance.setWallIsAlive(false);
            GameManager.Instance.setPoints(true);
            Destroy(gameObject);
        }

    }
}
