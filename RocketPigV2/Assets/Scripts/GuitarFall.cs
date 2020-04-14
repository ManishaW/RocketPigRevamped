using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarFall : MonoBehaviour
{
    public GameObject guitar;
    public GameObject newGuitar;
    public static GuitarFall instance;
    public GameObject Ufo;
	public static bool spawnedGuitarOnce;
	public static bool allowGuitarSpawn;
    Vector3 positionUfo;
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
		spawnedGuitarOnce = false;
        // float randoTime = Random.Range(15f, 20f);
        // InvokeRepeating ("makeGuitar", 20f, randoTime);
        // makeGuitar();
    }

    // Update is called once per frame
    void Update()
    {

    }
	// public static void triggerGuitarSpawn(){
	// 	instance.Invoke("makeGuitar",1.1f);
	// }

    // public void makeGuitar()
    // {
    //     // positionUfo = Ufo.transform.position;
    //     // Debug.Log(positionUfo);
    //     Vector3 position = new Vector3(Random.Range(-290, 290), 540, 0);
    //     newGuitar = Instantiate(guitar, position, Quaternion.identity) as GameObject;
    //     newGuitar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
    //     newGuitar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -40, 0);
    // }
}
