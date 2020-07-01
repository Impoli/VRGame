using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public bool isEmpty = true;
    private bool isRespawned = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when wall died all blocks get distroyed, but on distroing onTriggerExit is not called.
        // so "isEmpty" is reseted to true in this way
        if (!GameManager.Instance.wallIsAlive && !isRespawned)
        {
            isEmpty = true;
            isRespawned = true;
        }
        if (GameManager.Instance.wallIsAlive)
        {
            isRespawned = false;
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
