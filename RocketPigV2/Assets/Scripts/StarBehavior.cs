using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    GameObject piggy;
    Rigidbody2D rb;
    Vector2 rpDirection;

    float timeStamp;
    bool flyToPig;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (flyToPig && !RocketPig.die)
        {
            rpDirection = -(transform.position - piggy.transform.position).normalized;
            rb.velocity = new Vector2(rpDirection.x, rpDirection.y) * 100f * (Time.time / timeStamp);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "MagnetRadius" && RocketPig.magnetic)
        {
            timeStamp = Time.time;
            piggy = GameObject.Find("Pig");
            flyToPig = true;
        } 
       
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name == "MagnetRadius" && RocketPig.magnetic)
        {
            timeStamp = Time.time;
            //     	Debug.Log(RocketPig.magnetic);
            // Debug.Log("ehehhehe");
            piggy = GameObject.Find("Pig");
            flyToPig = true;
        }
     
    }
}
