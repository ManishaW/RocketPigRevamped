using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarFall : MonoBehaviour
{
    public GameObject guitar;
    public GameObject newGuitar;
    public static GuitarFall instance;
	public static bool spawnedGuitarOnce;
	public static bool allowGuitarSpawn;
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
	public static void triggerGuitarSpawn(){
		instance.Invoke("makeGuitar",0.3f);
	}

    public void makeGuitar()
    {
        Vector3 position = new Vector3(Random.Range(-325, 325), 800, 0);
        newGuitar = Instantiate(guitar, position, Quaternion.identity) as GameObject;
        newGuitar.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        newGuitar.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -30, 0);
    }
}
