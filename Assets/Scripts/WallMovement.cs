using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallMovement : MonoBehaviour
{
    private Transform podest;
    private bool wallPassedPodestRef = false;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody rigidbody = GetComponent<Rigidbody>();
        ////rigidbody.velocity = new Vector3(0, 0, -0.1f);
        //rigidbody.AddForce(new Vector3(0, 0, -0.2f));
        podest = GameObject.Find("Podest").transform;
    }

    // Update is called once per frame
    void Update()
    {
     
        if((podest.position.z + 1) > transform.position.z)
        {
            wallPassedPodestRef = true;
        }
        else
        {
            wallPassedPodestRef = false;
        }

        if((OVRInput.Get(OVRInput.Button.One)) && !wallPassedPodestRef )
        {
            transform.position += new Vector3(0, 0, -2.5f * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0, 0, -0.5f * Time.deltaTime);
        }
      
    }
}
