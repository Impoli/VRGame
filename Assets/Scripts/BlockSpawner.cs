using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject allBlocks;
    public float spawnTime = 0.5f;

    private GameObject spawnTrigger1;
    private GameObject spawnTrigger2;
    //private GameObject spawnTrigger3;
    private Transform parent;

    private float deltaSum = 0;
    private GameObject[] usedBlocks;

    // Start is called before the first frame update
    void Start()
    {
        spawnTrigger1 = GameObject.Find("SpawnTrigger1");
        spawnTrigger2 = GameObject.Find("SpawnTrigger2");
        //spawnTrigger3 = GameObject.Find("SpawnTrigger3");
        parent = GameObject.Find("SpawnedBlocks").transform;

        usedBlocks = new GameObject[allBlocks.transform.childCount];
        for (int i = 0; i < allBlocks.transform.childCount; i++ )
        {
            usedBlocks[i] = allBlocks.transform.GetChild(i).gameObject;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        deltaSum += Time.deltaTime;

        if (GameManager.Instance.wallIsAlive)
        {
            if (spawnTrigger1.GetComponent<SpawnTrigger>().isEmpty && deltaSum >= spawnTime)
            {
                deltaSum = 0;
                SpawnBlock(spawnTrigger1);
            }


            if (spawnTrigger2.GetComponent<SpawnTrigger>().isEmpty && deltaSum >= spawnTime)
            {
                deltaSum = 0;
                SpawnBlock(spawnTrigger2);
            }
        }
        

   
    }

    void SpawnBlock(GameObject trigger)
    {  

        GameObject newBlock = Instantiate(GetRandomBlock(), parent);
        Vector3 pos = trigger.transform.position;
        newBlock.transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
    }

    GameObject GetRandomBlock()
    {
        List<GameObject> currentBlocks = new List<GameObject>();

        foreach (var bl in usedBlocks)
        {
            int prob = (int)bl.GetComponent<BlockPoints>().probability;
            if (prob != 0)
            {
                int ranProb = Random.Range(1, prob + 1);
                if (ranProb == 1)
                {
                    currentBlocks.Add(bl);
                }
            }
        }

        int blockNum = Random.Range(0,currentBlocks.Count);
        return currentBlocks[blockNum];


        //GameObject block = null;
        //while (block == null)
        //{

        //    int blockNum = Random.Range(0, usedBlocks.Length);
        //    int prob = (int)usedBlocks[blockNum].GetComponent<BlockPoints>().probability;
        //    //Debug.Log("Prob: " + prob);

        //    if ( prob != 0)
        //    {
        //        int balancing = 2; // the higher the value the less difference between probabilities
        //        int ranProb = Random.Range(1, prob + balancing);
        //        //Debug.Log(ranProb);
        //        if (ranProb == 1)
        //        {
        //            block = usedBlocks[blockNum];
        //        }

        //    }
        //}

    }
}
