using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject allBlocks;
    public float spawnTime = 0.5f;

    private GameObject spawnTrigger1;
    private GameObject spawnTrigger2;
    private GameObject spawnTrigger3;
    private Transform parent;

    private float deltaSum = 0;
    private GameObject[] usedBlocks;

    // Start is called before the first frame update
    void Start()
    {
        spawnTrigger1 = GameObject.Find("SpawnTrigger1");
        spawnTrigger2 = GameObject.Find("SpawnTrigger2");
        spawnTrigger3 = GameObject.Find("SpawnTrigger3");
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

        if (spawnTrigger3.GetComponent<SpawnTrigger>().isEmpty && deltaSum >= spawnTime)
        {
            deltaSum = 0;
            SpawnBlock(spawnTrigger3);
        }

    }

    void SpawnBlock(GameObject trigger)
    {
        int blockNum = Random.Range(0, usedBlocks.Length);

        GameObject newBlock = Instantiate(usedBlocks[blockNum], parent);
        Vector3 pos = trigger.transform.position;
        newBlock.transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
    }
}
