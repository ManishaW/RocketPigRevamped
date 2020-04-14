using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowOrbMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -40, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
