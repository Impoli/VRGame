using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject allWalls;

    private GameObject[] usedwalls;
    private float timeSume = 0;

    // Start is called before the first frame update
    void Start()
    {
        usedwalls = new GameObject[allWalls.transform.childCount];
        for (int i = 0; i < allWalls.transform.childCount; i++)
        {
            usedwalls[i] = allWalls.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame 
    void Update()
    {
        
        if (!GameManager.Instance.wallIsAlive && GameManager.Instance.tutorialEnded && !GameManager.Instance.GameOver)
        {
            timeSume += Time.deltaTime;
            if (timeSume >= 0.5)
            {
                timeSume = 0;
      
                int wallNum = Random.Range(0, usedwalls.Length);
                //wallNum = 1;
                GameObject newBlock = Instantiate(usedwalls[wallNum], transform);
                Vector3 pos = transform.position;
                newBlock.transform.position = new Vector3(pos.x, pos.y, pos.z);
                GameManager.Instance.setWallIsAlive(true);
            }
            
        }
    }
}
