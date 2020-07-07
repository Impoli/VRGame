using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemplateStartHandler : MonoBehaviour
{
    public bool isStarted { get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.wallIsAlive)
        {
            isStarted = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "block")
        {
            isStarted = true;
        }
    }
}
