using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCometsScript : MonoBehaviour
{
    public float speed;
    public float maxRotation;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.9f,1.3f);
        maxRotation = Random.Range(25f,40f);
        transform.rotation = Quaternion.Euler(0f,0f,Random.Range(0f,360f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }
}
