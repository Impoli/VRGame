using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    private Light torch;
    private float timeSum = 0;
    private float duration = 0.2f;

    public LightingMode lightingMode = LightingMode.Tunnel;

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
            torch.intensity = Random.Range(lightingMode.GetIntense()[0], lightingMode.GetIntense()[1]);
            duration = Random.Range(0.01f, 0.3f);
            timeSum = 0;
        }
        
    }
}

public enum LightingMode
{
   Wall,
   Tunnel
}


// extension für enum: PlayerSpeed
static class PlayerSpeedMethods
{

    public static float [] GetIntense(this LightingMode p1)
    {
        switch (p1)
        {
            case LightingMode.Wall:
                return new float[] { 0.1f, 0.3f };
            case LightingMode.Tunnel:
                return new float[] { 0.01f, 0.3f };
            default:
                return new float[] {0f, 0f };

        }
    }

    public static float GetEndVal(this LightingMode p1)
    {
        switch (p1)
        {
            case LightingMode.Wall:
                return 0.25f;
            case LightingMode.Tunnel:
                return 0.3f;
            default: return 0;

        }
    }
}