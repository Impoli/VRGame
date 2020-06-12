using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeCustomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 sizeStd = GetComponent<Renderer>().bounds.size;
        //GetComponent<Renderer>().bounds= new Vector3(GameManager.Instance.currentWallGap, sizeStd.y, sizeStd.z);
        if ((GameManager.Instance.currentWallGapX != 0))
        {
            newScale(gameObject, GameManager.Instance.currentWallGapX);

        }
       
       //Debug.Log("Ref Plate: " + GetComponent<Renderer>().bounds.size.x);
    }

    public void newScale(GameObject theGameObject, float newSize)
    {
        float size = theGameObject.GetComponent<Renderer>().bounds.size.x;
        Vector3 rescale = theGameObject.transform.localScale;
        rescale.x = newSize * rescale.x / size;
        theGameObject.transform.localScale = rescale;

    }
}
