using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public bool isEmpty = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.wallIsAlive)
        {
            isEmpty = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isEmpty = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isEmpty = true;
    }


}
