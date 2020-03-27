using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometFall : MonoBehaviour
{
    public GameObject comet;
    public GameObject newComet;

    void Start()
    {
        // float startRando = Random.Range (0.5f,1.5f);
        // float endRando = Random.Range (2.5f,4f);
        float randoTime = Random.Range(1f, 5f);
        InvokeRepeating("makeComet", 5f, randoTime);

    }
    void Update()
    {
	
    }
    void makeComet()
    {
        if (RocketPig.die == false && PlayGameScene.fuelCounter > 0 && PlayGameScene.blastOffTriggered && !RocketPig.rainbowSequenceOn)
        {
            //Debug.Log ("Create comet");
            Vector3 position = new Vector3(Random.Range(-350, 350), 1000, 0);
            // comet.GetComponent<Rigidbody2D>().gravityScale = Random.Range (3, 5);
            comet.transform.localScale = new Vector3(1, 1, 0);
            float scale = Random.Range(1.5f, 4.5f);

            // comet.transform.localScale += new Vector3 (scale, scale, 0);

            newComet = Instantiate(comet, position, Quaternion.identity) as GameObject;
            newComet.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            newComet.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -45, 0);
            newComet.transform.localScale = new Vector3(scale, scale, 0);

        }
    }

 

}
