using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject block1;

    private GameObject spawnTrigger1;
    private GameObject spawnTrigger2;
    private GameObject spawnTrigger3;
    private Transform parent;

    private float deltaSum = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnTrigger1 = GameObject.Find("SpawnTrigger1");
        spawnTrigger2 = GameObject.Find("SpawnTrigger2");
        spawnTrigger3 = GameObject.Find("SpawnTrigger3");
        parent = GameObject.Find("SpawnedBlocks").transform;

       
    }

    // Update is called once per frame
    void Update()
    {
        deltaSum += Time.deltaTime;

        if (spawnTrigger1.GetComponent<SpawnTrigger>().isEmpty && deltaSum >= 0.5f)
        {
            deltaSum = 0;
            GameObject newBlock = Instantiate(block1, parent);
            Vector3 pos = spawnTrigger1.transform.position;
            newBlock.transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        }


        if (spawnTrigger2.GetComponent<SpawnTrigger>().isEmpty && deltaSum >= 0.5f)
        {
            deltaSum = 0;
            GameObject newBlock = Instantiate(block1, parent);
            Vector3 pos = spawnTrigger2.transform.position;
            newBlock.transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        }

            if (spawnTrigger3.GetComponent<SpawnTrigger>().isEmpty && deltaSum >= 0.5f)
        {
            deltaSum = 0;
            GameObject newBlock = Instantiate(block1, parent);
            Vector3 pos = spawnTrigger3.transform.position;
            newBlock.transform.position = new Vector3(pos.x, pos.y + 0.5f, pos.z);
        }

    }
}
