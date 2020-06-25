using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDisabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.tutorialEnded)
        {
            gameObject.SetActive(false);
        }
    }
}
