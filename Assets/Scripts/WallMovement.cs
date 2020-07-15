using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallMovement : MonoBehaviour
{
    private Transform podest;
    private bool wallPassedPodestRef = false;
    private float speedNormal;
    private float speedFast;

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

        speedNormal = GameManager.Instance.wallSpeedNormal;
        speedFast = GameManager.Instance.wallSpeedFast;

        if((podest.position.z + 1) > transform.position.z)
        {
            wallPassedPodestRef = true;
        }
        else
        {
            wallPassedPodestRef = false;
        }

        if(((OVRInput.Get(OVRInput.Button.One)) || Input.GetKey(KeyCode.A ) || GameManager.Instance.templateIsEnabled) && !wallPassedPodestRef )
        {
            transform.position += new Vector3(0, 0, -speedFast * Time.deltaTime);
        }
        else
        {
            transform.position += new Vector3(0, 0, -speedNormal * Time.deltaTime);
        }
      
    }
}
