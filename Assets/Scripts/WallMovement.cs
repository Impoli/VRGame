using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody rigidbody = GetComponent<Rigidbody>();
        ////rigidbody.velocity = new Vector3(0, 0, -0.1f);
        //rigidbody.AddForce(new Vector3(0, 0, -0.2f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -0.2f * Time.deltaTime);
      
    }
}
