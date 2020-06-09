using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDetection : MonoBehaviour
{

    public float standTime = 1;
    private bool wallHasPassed = false;
    private bool startPointDetection = false;

    private float deltaSum;
    private int points = 0;
    private int currentPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject podestPlate = GameObject.Find("PodestPlate");
        //transform.localScale.Set(podestPlate.transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {
        deltaSum += Time.deltaTime;

        if( wallHasPassed && deltaSum >= standTime)
        {
            startPointDetection = true;
            transform.position -= new Vector3(0.1f, 0, 0) ;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        // Point detection starts when wall has passed
        if ( other.name == "WallPlane")
        {
            wallHasPassed = true;
            deltaSum = 0;
        }

        if (startPointDetection)
        {
            if (other.tag == "block" && !other.GetComponent<BlockPoints>().getIsInErrorPosition())
            {
                points += other.GetComponent<BlockPoints>().Points;
                GameManager.Instance.addPoints(other.GetComponent<BlockPoints>().Points);
                //GameObject pt = GameObject.Find("PointsText");
                //pt.GetComponent<UnityEngine.UI.Text>().text = "Points: " + points;
            }

        }

        if (other.tag == "block")
        {
            if (other.GetComponent<BlockPoints>().pointsCounted)
            {
                other.GetComponent<BlockPoints>().setPointsCounted(false);

            }
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "block" && !other.GetComponent<BlockPoints>().getIsInErrorPosition())
        {
            if(!other.GetComponent<BlockPoints>().pointsCounted)
            {
                other.GetComponent<BlockPoints>().setPointsCounted(true);
            }
        }
        if (other.tag == "block" && other.GetComponent<BlockPoints>().getIsInErrorPosition())
        {
            if (other.GetComponent<BlockPoints>().pointsCounted)
            {
                other.GetComponent<BlockPoints>().setPointsCounted(false);
            }
        }


    }
}
