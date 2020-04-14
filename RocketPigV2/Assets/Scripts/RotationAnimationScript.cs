using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimationScript : MonoBehaviour
{
      public float rotationSpeed = 20.0f; // Degrees per second
    // Start is called before the first frame update
    void Start()
    {
         if (gameObject.name=="heartFuelUp(Clone"){
            rotationSpeed =Random.Range(50,65);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (0, 0, rotationSpeed) * Time.deltaTime);
    }
}
