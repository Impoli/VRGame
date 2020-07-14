﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateHandler : MonoBehaviour
{

    private Transform podestRef;
    private float timeSum = 0;
    private float clickTimeSum = 0;
    private float activeTimeOnStart = 2;
    private float timeEnabledAfterClick = 1;
    private bool keyPressedFirstTime = false;
    private TemplateStartHandler startTrigger;

    // Start is called before the first frame update
    void Start()
    {
        podestRef = GameObject.Find("Podest_Temp_Ref").transform;
        startTrigger = GameObject.Find("TempStartTrigger").GetComponentInChildren<TemplateStartHandler>();
        transform.position = podestRef.position;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        clickTimeSum = timeEnabledAfterClick;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.wallIsAlive)
        {
            Destroy(gameObject);
        }

        timeSum += Time.deltaTime;

        if (!startTrigger.isStarted)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else  if (((OVRInput.Get(OVRInput.Button.One)) || Input.GetKey(KeyCode.A)) || clickTimeSum < timeEnabledAfterClick)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            clickTimeSum += Time.deltaTime;
            GameManager.Instance.setTemplateIsEnabled(true);
            if (!keyPressedFirstTime)
            {
                keyPressedFirstTime = true;
                clickTimeSum = 0;
            }
        }
        else
        {
            keyPressedFirstTime = false;
            GameManager.Instance.setTemplateIsEnabled(false);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            clickTimeSum = timeEnabledAfterClick;
        }
        
      
    }
}
