using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPoints : MonoBehaviour
{
    public int Points = 5;
    public SpawnProbability probability = SpawnProbability.High;
    public Material errorMaterial;
    public Material standartMaterial;

    public bool pointsCounted { get; private set; } = false;
    private bool isInPointsArea = false;
    private bool inErrorPosition = false;

    private bool rPT_1IsTriggerd = false;
    private bool rPT_2IsTriggerd = false;


    private void Update()
    {

        if (inErrorPosition)
        {
            GetComponent<MeshRenderer>().material = errorMaterial;
        }
        else
        {
            GetComponent<MeshRenderer>().material = standartMaterial;
        }

        if (GameManager.Instance.despawnBlocks)
        {
            if (!inErrorPosition && isInPointsArea)
            {
                GameManager.Instance.addCurrrentPoints(-Points);
            }
            Destroy(gameObject);
        }
    }

    public bool getIsInErrorPosition()
    {
        return inErrorPosition;
    }

    public void setPointsCounted(bool b)
    {
        if (!pointsCounted && b)
        {
            GameManager.Instance.addCurrrentPoints(Points);
        }
        if (pointsCounted && !b)
        {
            GameManager.Instance.addCurrrentPoints(-Points);
        }
        pointsCounted = b;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "PointsTrigger")
        {
            isInPointsArea = true;
        }

        if(isInPointsArea && other.name == "ErrorPositionTrigger_1")
        {
            inErrorPosition = true;
            rPT_1IsTriggerd = true;
        }

        if( isInPointsArea && other.name == "ErrorPositionTrigger_2")
        {
            inErrorPosition = true;
            rPT_2IsTriggerd = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "PointsTrigger")
        {
            isInPointsArea = false;
        }

        if (other.name == "ErrorPositionTrigger_1")
        {  
            rPT_1IsTriggerd = false;

            if(!rPT_1IsTriggerd && !rPT_2IsTriggerd)
            {
                inErrorPosition = false;
            }
        }

        if ( other.name == "ErrorPositionTrigger_2")
        {
            rPT_2IsTriggerd = false;

            if (!rPT_1IsTriggerd && !rPT_2IsTriggerd)
            {
                inErrorPosition = false;
            }
        }


    }

}

public enum SpawnProbability : int
{
    None = 0,
    Low = 3,
    Middle = 2,
    High = 1
}


