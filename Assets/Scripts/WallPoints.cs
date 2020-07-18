using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPoints : MonoBehaviour
{

    private AudioSource audioSource;
    public int wallPoints = 0;
    private GameObject refCube;
    private float startDistanceToPodest = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.setWallPoints(wallPoints);
       
        for (int i = 0; i < gameObject.transform.childCount ; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.tag == "wallRefCube")
            {
                refCube = gameObject.transform.GetChild(i).gameObject;
            }
        }

        transform.position += new Vector3(0, -2.5f, 0);
        startDistanceToPodest = Mathf.Abs(GameObject.Find("Podest_schiene").transform.position.z - transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        float currDistance = Mathf.Abs(GameObject.Find("Podest_schiene").transform.position.z - transform.position.z);
        audioSource.volume = (1 * 0.6f) - (currDistance/ startDistanceToPodest * 0.6f);

        GameManager.Instance.setCurrentWallGapX(refCube.GetComponent<Renderer>().bounds.size.x);

        if (GameManager.Instance.points >= wallPoints)
        {
            //GameManager.Instance.setWallIsAlive(false);
            //GameManager.Instance.setPoints(true);
            // Destroy(gameObject);
        }

        if (GameObject.Find("Podest_schiene").transform.position.z - transform.position.z > 0.15)
        {
            gameObject.GetComponentInChildren<MeshCollider>().enabled = false;
            gameObject.GetComponent<WallMovement>().enabled = false;
            transform.position += new Vector3(0, -1f * Time.deltaTime, 0);

            if (GameManager.Instance.points < wallPoints)
            {
                GameManager.Instance.setGameOver(true);
            }

            if (transform.position.y < -2.5)
            {
                GameManager.Instance.setWallIsAlive(false);
                GameManager.Instance.setPoints(true);
                Destroy(gameObject);
            }
            
        }
        else
        {
            if (transform.position.y < 0)
            {
                transform.position += new Vector3(0, 1f * Time.deltaTime, 0);
            }
        }

    }
}
