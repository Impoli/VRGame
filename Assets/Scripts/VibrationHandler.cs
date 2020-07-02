using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationHandler : MonoBehaviour
{
    public GameObject Block;
    private GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Parent = Block.transform.parent.gameObject;
            if (Parent.name != "RightHandAnchor" && Parent.name != "LeftHandAnchor")
                Parent = null;
        }catch(NullReferenceException e)
        {
            Parent = null;
        }
        if (Parent != null)
        {
            if (Parent.tag == "LeftHand")
            {
                Debug.Log("Block Held in Left Hand");
            }
            if (Parent.tag == "RightHand")
            {
                Debug.Log("Block Held in Right Hand");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "LeftHand" && collision.gameObject.tag != "RightHand" && Parent != null)
        {
            if (Parent.tag == "LeftHand")
            {
                Debug.Log("Block in Left Hand Collided");
                OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.LTouch);
            }
            if (Parent.tag == "RightHand")
            {
                Debug.Log("Block in Right Hand Collided");
                OVRInput.SetControllerVibration(0.1f, 0.1f, OVRInput.Controller.RTouch);
            }
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "LeftHand" && collision.gameObject.tag != "RightHand" && Parent != null)
        {
            if (Parent.tag == "LeftHand")
            {
                Debug.Log("Block in Left Hand Collided");
                OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.LTouch);
            }
            if (Parent.tag == "RightHand")
            {
                Debug.Log("Block in Right Hand Collided");
                OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.RTouch);
            }

        }
    }
}
