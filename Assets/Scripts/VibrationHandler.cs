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
        Parent = null;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag != "LeftHand" && collision.gameObject.tag != "RightHand" && Parent != null)
        {
            if (Parent.tag == "LeftHand")
            {
                Debug.Log("Block Held in Left Hand");
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
            }
            if (Parent.tag == "RightHand")
            {
                Debug.Log("Block Held in Right Hand");
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            }
            
        }
    }
}
