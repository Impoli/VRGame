using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    private Light torch;
    private float timeSum = 0;
    private float duration = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        torch = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;

        if (timeSum >= duration)
        {
            torch.intensity = Random.Range(0.3f, 0.9f);
            duration = Random.Range(0.01f, 0.3f);
            timeSum = 0;
        }
        

    }
}
