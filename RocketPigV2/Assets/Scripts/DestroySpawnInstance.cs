using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnInstance : MonoBehaviour
{

    void Start()
    {
       

    }
    void Update()
    {
        if (RocketPig.rainbowSequenceOn && this.gameObject.name !="heartFuelUp(Clone)"){
            Destroy(this.gameObject);
        }
         if (RocketPig.die){
            Destroy(this.gameObject);
        }
       
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
